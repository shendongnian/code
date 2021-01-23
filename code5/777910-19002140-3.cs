    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test()
        {
            Iconnection connection = new FakeConnection();
            WCF classUnderTest = new WCF(connection);
            //Run test logic
        }
    }
