    [TestFixture()]
    class NUnitSeleniumTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            driverIE = new InternetExplorerDriver(ConfigurationManager.AppSettings["IEDriver"]);
            driverIE.Manage().Window.Maximize();
            // other setup logic
        }
        [Test]
        public void TestMethod1()
        {
            // Test logic
        }
        [Test]
        public void TestMethod2()
        {
            // Test logic
        }
        ...
        ...
        ...
        [Test]
        public void TestMethodN()
        {
            // Test logic
        }
        
        [OneTimeTearDown]
        public void  Close()
        {
            driverIE.Close();
        }
    }
