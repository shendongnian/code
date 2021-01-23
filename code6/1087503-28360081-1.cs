    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInterfaceMock()
        {
            var testableSut = new TestableDataService(new Employee() {Id = 101,Name = "Mock Employee"});
            var result = testableSut.TestMethodB();
           Assert.AreEqual(result.Name, "Mock Employee");
           Assert.AreEqual(result.Id, "101");
        }
    }
