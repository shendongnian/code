    [TestClass]
    public class UnitTest1
    {
        FirefoxDriver firefox;
        // This is the test to be carried out.
        [TestMethod]
        public void TestMethod1()
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl("http://www.google.com/");
            IWebElement element = firefox.FindElement(By.Id("lst-ib"));
            element.SendKeys("Google\n");
        }
        // This closes the driver down after the test has finished.
        [TestCleanup]
        public void TearDown()
        {
            firefox.Quit();
        }
    }
