    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.XPath;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Firefox;
    using NUnit.Framework;
    
    namespace BMCPerceiver
    {
        public class Class1
        {
            public void Method1()
            {
                // Step b - Initiating webdriver
                IWebDriver driver = new FirefoxDriver();
    
                //Step c : Making driver to navigate
                driver.Navigate().GoToUrl("http://docs.seleniumhq.org/");
    
                //Step d 
                IWebElement myLink = driver.FindElement(By.LinkText("Download"));
                myLink.Click();
    
                //Step e
                driver.Quit();
            }
        }
    }
