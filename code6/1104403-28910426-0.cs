    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
             var service = new MyService();
             int SomeProperInteger = GetNextInteger();
             double SomeProperAmount = .50;
             var actual = service.GetTotalSum(SomeProperInteger);
             double expected = SomeProperInteger * SomeProperAmount;
             Assert.IsTrue(expected = actual, "Test Failed, Expected amount was incorrect.");
        }
        private int GetNextInteger()
        {
            throw new System.NotImplementedException();
        }
    }
