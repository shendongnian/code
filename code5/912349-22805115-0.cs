    public class Class1 : IUseFixture<FirefoxDriver>
    {
        private FirefoxDriver driver;
    
        public void SetFixture(FirefoxDriver data)
        {
            driver = new FirefoxDriver();
        }
    
        [Fact]
        public void Test()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElementById("gbqfq").SendKeys("Testing");
        }
    
        [Fact]
        public void Test2()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElementById("gbqfq").SendKeys("Testing again");
        }    
    }
