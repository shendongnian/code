    [TestClass]
    public class OrderedTests
    {
        public TestContext TestContext { get; set; }
        private const string _OrderedTestFilename = "TestList.csv";
        [TestMethod]
        [DeploymentItem(_OrderedTestFilename)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", _OrderedTestFilename, _OrderedTestFilename, DataAccessMethod.Sequential)]
        public void OrderedTests()
        {
            var methodName = (string)TestContext.DataRow[0];
            var method = GetType().GetMethod(methodName);
            method.Invoke(this, new object[] { });
        }
        public void Method_01()
        {
            Assert.IsTrue(true);
        }
        public void Method_02()
        {
            Assert.IsTrue(false);
        }
        public void Method_03()
        {
            Assert.IsTrue(true);
        }
    }
