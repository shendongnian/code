    [TestFixture]
    public class TestBase
    {
        public string Browser { get; set; }
        public IWebDriver Driver { get; set; }
        public TestBase( string _browser){ this.Browser = _browswer }
        [SetUp]
        public Setup(){
            Driver = SeleniumExtension.GetDriver(Browser);
        }
    }
