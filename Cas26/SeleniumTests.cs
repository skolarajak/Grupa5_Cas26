using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Cas26
{
    class SeleniumTests
    {
        IWebDriver driverF;
        IWebDriver driverC;
        string url = "https://www.google.com";

        [Test]
        public void TestGoogleSearchInFF()
        {
            driverF = new FirefoxDriver();
            GoToWebsite(driverF, url, 1500);
            IWebElement searchField = FindElement(driverF, By.Name("q"));
            if (searchField != null)
            {
                SendKeys(searchField, "C# selenium tests", 1000);
            }
            Wait(3000);
            driverF.Close();
        }

        [Test]
        public void TestGoogleSearchInChrome()
        {
            driverC = new ChromeDriver();
            GoToWebsite(driverC, url, 1500);
            IWebElement searchField = FindElement(driverC, By.Name("q"));
            if (searchField != null)
            {
                SendKeys(searchField, "C# selenium tests", 1000);
            }
            Wait(3000);
            driverC.Close();
        }

        private void SendKeys(IWebElement element, string keys, int ms, bool sendEnter = true)
        {
            element.SendKeys(keys);
            Wait(ms);
            if (sendEnter)
            {
                element.SendKeys(Keys.Enter);
            }
        }

        public IWebElement FindElement(IWebDriver driver, By selector)
        {
            IWebElement elReturn = null;

            try
            {
                elReturn = driver.FindElement(selector);
            } catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw e;
            }

            return elReturn;
        }

        private void GoToWebsite(IWebDriver driver, string url, int ms)
        {
            driver.Manage().Window.Maximize();
            Wait(ms);
            driver.Navigate().GoToUrl(url);
            Wait(ms);
        }

        static private void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        [SetUp]
        public void Init()
        {
            // Use firefox browser
            //driverF = new FirefoxDriver();

            // Use chrome browser
            //driverC = new ChromeDriver();
        }

        [TearDown]
        public void Destroy()
        {
            //driverF.Close();
            //driverC.Close();
        }

    }
}
