    [TestClass]
    public class BaseTestClass
    {
        private static int _executedTests;
        private static int _passedTests;
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("Total tests executed: {0}", _executedTests );
            Console.WriteLine("Total passed tests: {0}", _passedTests);
        }
        protected void IncrementTests()
        {
            _executedTests++;
        }
        protected void IncrementPassedTests()
        {
            _passedTests++;
        }
    }
    [TestClass]
    public class TestClass : BaseTestClass
    {
        [TestInitialize]
        public void TestInitialize()
        {
            IncrementTests();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                IncrementPassedTests();
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.Fail();
        }
        public TestContext TestContext { get; set; }
    }
