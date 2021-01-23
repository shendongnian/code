    [TestClass]
    public class TestMock
    {
        [TestMethod]
        public void TestMockingUserManager()
        {
            var mock = new Mock<IWrapUserManager>();
            //setup your mock with methods and return stuff here.
            var testClass = new ClassToTest(mock.Object); //you are now mocking your class that wraps up UserManager.
            //test your class with a mocked out UserManager here.
        }
    }
