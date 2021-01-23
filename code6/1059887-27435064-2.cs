    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var client = new Client();
            var john = client.Get<Person>(p => p.Name == "John");
            Assert.IsNotNull(john);
        }
    }
