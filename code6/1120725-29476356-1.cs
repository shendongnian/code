    [TestFixture]
    public class YourFixture
    {
        private TransactionScope scope;
    
        [SetUp]
        public void TestSetUp()
        {
            scope = new TransactionScope();
        }
    
        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }
    
    
        [Test]
        public void SomeTest()
        {
            // here comes your test 
        }
    }
