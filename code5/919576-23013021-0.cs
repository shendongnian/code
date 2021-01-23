    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestMethod1()
        {
			Assert.AreEqual("TestMethod1", TestContext.TestName, "Something went really wrong...");
        }
        public TestContext TestContext { get; set; }
    }
