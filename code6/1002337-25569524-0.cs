    [CodedUITest]
    public class MyTestClass
    {
        [ClassInitialize]
        public void DoSomethingFirst()
        {
            // your code here that will run at the beginning of each test run.
        }
        
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            // your test initialization here
        }
        [TestMethod]
        public void MyTestMethod()
        {
        }
    }
