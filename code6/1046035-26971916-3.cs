    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    namespace SeleniumTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a web driver that used Firefox
                var driver = new FirefoxDriver(
                    new FirefoxBinary(), new FirefoxProfile(), TimeSpan.FromSeconds(120));
                // Load your page
                driver.Navigate().GoToUrl("http://google.com");
                // Wait until the page has actually loaded
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                wait.Until(d => d.Title.Contains("Google"));
                // Take a screenshot, and saves it to a file (you must have full access rights to the save location).
                var myDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(Path.Combine(myDesktop, "google-screenshot.png"), ImageFormat.Png);
                driver.Close();
            }
        }
    }
