    [TestFixture]
    class LoginTest
    {        
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.tesst.com");
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _driver.Quit();
        }
        [TestCase("kyos_enlaceIrAMovsCuenta_EUR0")]
        public void PaywallClosedArticleCommertialTest(string element)
        {
            _driver.FindElement(By.Id(element)).Click();
            //add assert
        }
    }  
