    [CodedUITest]
    public class MyTestClass
    {
        private TestContext testContext;
        private static int countFailedIterations = 0;
        private static string currentMethod = "";
    
        public MyTestClass()
        {
            if (!currentMethod.Equals(testContext.FullyQualifiedTestClassName))
            {
                // Reset Iteration Count
                countFailedIterations = 0;
                currentMethod = testContext.FullyQualifiedTestClassName;
            }
        }
    
        [TestInitialize]
        public void MyTestInit()
        {
            if (countFailedIterations > 0)
                Assert.Inconclusive("Stop it, please");
        }
    
        [TestCleanup]
        public void MytestCleanup()
        {
            if (testContext.CurrentTestOutcome != UnitTestOutcome.Passed)
                countFailedIterations++;
        }
    
        [TestMethod]
        [DataSource("MyDataSource")]
        public void MyTestMethod()
        {
            //Blah Blah Blah
        }
    
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
    }
