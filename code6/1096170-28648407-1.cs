    namespace AppiumTests
    {
      using System;
      // .NET unit test namespaces needed here as well, just not mentioning them
      using OpenQA.Selenium; /* Appium is based on Selenium, we need to include it */
      using OpenQA.Selenium.Appium; /* This is Appium */
    
      [TestClass]
      public class TestSuite
      {
        private AppiumDriver driver;
    
        private static Uri testServerAddress = new Uri("http:127.0.01:4723/wd/hub"); // If Appium is running locally
        private static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180); /* Change this to a more reasonable value */
        private static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10); /* Change this to a more reasonable value */
    
        [TestInitialize]
        public void BeforeAll()
        {
          DesiredCapabilities testCapabilities = new DesiredCapabilities();
    
          testCapabilities.App = "";
          testCapabilities.AutoWebView = true;
          testCapabilities.AutomationName = "";
          testCapabilities.BrowserName = String.Empty; // Leave empty otherwise you test on browsers
          testCapabilities.DeviceName = "Needed if testing on IOS on a specific device. This will be the UDID";
          testCapabilities.FwkVersion = "1.0"; // Not really needed
          testCapabilities.Platform = TestCapabilities.DevicePlatform.Android; // Or IOS
          testCapabilities.PlatformVersion = String.Empty; // Not really needed
    
          driver = new AppiumDriver(testServerAddress, capabilities, INIT_TIMEOUT_SEC);
          driver.Manage().Timeouts().ImplicitlyWait(IMPLICIT_TIMEOUT_SEC);
        }
    
        [TestCleanup]
        public void AfterAll()
        {
          driver.Quit(); // Always quit, if you don't, next test session will fail
        }
    
        /// 
        /// Just a simple test to heck out Appium environment.
        /// 
        [TestMethod]
        public void CheckTestEnvironment()
        {
          var context = driver.GetContext();
          Assert.IsNotNull(context);
        }
      }
    }
