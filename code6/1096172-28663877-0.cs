    namespace poc
    {
        using NUnit.Framework;    
        using System;
        using OpenQA.Selenium; 
        using OpenQA.Selenium.Appium;
        using OpenQA.Selenium.Appium.Interfaces;
        using OpenQA.Selenium.Appium.MultiTouch;
        using OpenQA.Selenium.Interactions;
        using OpenQA.Selenium.Remote;
        using OpenQA.Selenium.Appium.Android;
    
        [TestFixture()]
        public class TestAppium
        {
            public IWebDriver driver;
    
            [TestFixtureSetUp]
            public void SetUp()
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability("device", "Android");
                capabilities.SetCapability("browserName", "chrome");
                capabilities.SetCapability("deviceName", "Motorola Moto g");
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("platformVersion", "5.0.2");
    
                 driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            }  
            
            [Test()]
            public void OpenHofHomePage()
            {
                driver.Navigate().GoToUrl("http://YourWebsiteToTest.com");
                Assert.IsTrue(driver.Title.Equals("Your Website")," Sorry , the website didnt open!!");
            }
             
            [TestFixtureTearDown]
            public void End()
            {
                driver.Dispose();
            }
        }
    }
