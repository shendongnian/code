    public enum Test
    {
        First,
        Second,
        Third
    }
    [TestClass]
    public class EnumTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var values = Enum<Test>.GetAll();
            Assert.AreEqual(3, values.Count());
        }
    }
