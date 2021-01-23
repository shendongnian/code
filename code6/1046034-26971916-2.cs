    using System;
    using System.Drawing;
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
                // Take a screenshot, and convert the returned byte array to an image.
                var byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                var ms = new MemoryStream(byteArray, 0, byteArray.Length);
                ms.Write(byteArray, 0, byteArray.Length);
                var screenshot = Image.FromStream(ms, true);
                // Save your screenshot somewhere
                screenshot.Save(@"C:\file.png", ImageFormat.Png);
                driver.Close();
            }
        }
    }
