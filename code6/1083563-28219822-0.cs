    [TestClass]
    public class UnitTests1 {
        MyStub stub;
        [TestInitialize]
        public void InitializeContext() { // Construct stub  }
        [TestCleanup]
        public void CleanupContext() { // Dispose stub }
        [TestMethod]
        public void Test1() { StubTests.TestMyStub(stub); }
        [TestMethod]
        public void Test2() { StubTests.TestMyStub2(stub); }
        ...
    }
    [TestClass]
    public class UnitTests2 {
        MyStub stub;
        [TestInitialize]
        public void InitializeContext() { // Construct stub  }
        [TestCleanup]
        public void CleanupContext() { // Dispose stub }
        [TestMethod]
        public void Test1() { StubTests.TestMyStub(stub); }
        [TestMethod]
        public void Test2() { StubTests.TestMyStub2(stub); }
        ...
    }
