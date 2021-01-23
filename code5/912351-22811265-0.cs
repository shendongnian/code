       public class SampleFixture : IDisposable
       {
        private IWebDriver driver;
        public SampleFixture()
        {
            driver = new FirefoxDriver();
            Console.WriteLine("SampleFixture constructor called");
        }
        public IWebDriver InitiateDriver()
        {
            return driver;
        }
        public void Dispose()
        {
           // driver.Close();
            driver.Quit();
            Console.WriteLine("Disposing Fixture");
        }
    }
    public class Class1 : IUseFixture<SampleFixture>
    {
        private IWebDriver driver;
        public void SetFixture(SampleFixture data)
        {
            driver = data.InitiateDriver();
        }
        [Fact]
        public void Test()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Id("gbqfq")).SendKeys("Testing");
        }
        [Fact]
        public void Test2()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Id("gbqfq")).SendKeys("Testing again");
        }
    }
