    namespace TestPage 
    { 
        [TestFixture(Browser.Firefox)]
        [TestFixture(Browser.Chrome)]
        [TestFixture(Browser.IE)]
        public class TestSetup : SetUps 
        {
    	public TestSetup (Browser browser)
            {
                driver = GetWebDriverForBrowser(browser);   // This part solved the issue.
            }      
      
    	[Test]
            public void TestPage()
            {
    
                driver.Navigate().GoToUrl(baseURL);
                ...
            }
    
        }
    }   
    
    
      namespace SetUps
        {
            public class SetUps
            {
                protected IWebDriver driver;
                protected StringBuilder verificationErrors;
                protected string baseURL;
    
                [SetUp]
                public void SetupTest()
                {
                    baseURL = "www.ggogle.com";
                    verificationErrors = new StringBuilder();
                }
    
                [TearDown]
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
                    Assert.AreEqual("", verificationErrors.ToString());
                }
                public enum Browser
                {
                    Chrome,
                    Firefox,
                    IE
                }
                public IWebDriver GetWebDriverForBrowser(Browser browser)
                {
                    IWebDriver driver = null;
    
                    switch (browser)
                    {
                        case Browser.Chrome:
                            driver = new ChromeDriver(@"C:\repos\Testing\Tests");
                            break;
    
                        case Browser.Firefox:
                            driver = new FirefoxDriver();
                            break;
    
                        case Browser.IE:
                            driver = new InternetExplorerDriver(@"C:\repos\Testing\Tests");
                            break;
                    }
    
                    if (driver != null)
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                    }
                    return driver;
                }
    
            }
        }
