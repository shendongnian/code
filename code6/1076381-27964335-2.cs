    [TestFixture]
    public class DbTestFixture
    {
        [TestFixtureSetUp]
        public void Init()
        {
            TestFactory.Setup();
        }
    
        [Test]
        public void YourTestHere()
        {
            var database = TestFactory.DbFactory.GetDatabase();
            ...
        }
    }
