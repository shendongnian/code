    [TestClass]
    public class UnitTestComputation
    {
        [TestMethod]
        public void TestFactorial()
        {
            Assert.AreEqual(1, Program.Factorial(0));
            Assert.AreEqual(1, Program.Factorial(1));
            Assert.AreEqual(2, Program.Factorial(2));
            Assert.AreEqual(6, Program.Factorial(3));
            Assert.AreEqual(24, Program.Factorial(4));
        }
    }
