    public interface IMyService
    {
        int GetData();
    }
    public class MyViewModel
    {
        private readonly IMyService myService;
        public MyViewModel(IMyService myService)
        {
            if (myService == null)
            {
                throw new ArgumentNullException("myService");
            }
            this.myService = myService;
        }
        public string ShowSomething()
        {
            return "Just a test " + this.myService.GetData();
        }
    }
    class TestClass
    {
        [TestMethod]
        public void TestMethod()
        {
            var serviceMock = new Mock<IMyService>();
            var objectUnderTest = new MyViewModel(serviceMock.Object);
            serviceMock.Setup(x => x.GetData()).Returns(42);
            var result = objectUnderTest.ShowSomething();
            Assert.AreEqual("Just a test 42", result);
        }
    }
