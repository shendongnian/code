    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    namespace SeleniumTests
    {
        public class Googletest
        {
            private IWebDriver driver;
            private WebDriverWait wait;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;
            public static void Main(string[] args)
            {
                var gt = new Googletest();
                gt.SetupTest();
                gt.TheGoogleTest();
                //gt.TeardownTest();
            }
            public void SetupTest()
            {
                driver = new FirefoxDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                baseURL = "https://www.google.com/";
                verificationErrors = new StringBuilder();
            }
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
            }
            public void TheGoogleTest()
            {
                driver.Navigate().GoToUrl(baseURL + "/");
                driver.FindElement(By.Id("gbqfq")).Clear();
                driver.FindElement(By.Id("gbqfq")).SendKeys("Cute Fluffy Cats");
                driver.FindElement(By.Id("gbqfb")).Click();
                wait.Until(d => d.FindElement(By.LinkText("Images"))).Click();
            
            }
            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }
            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }
