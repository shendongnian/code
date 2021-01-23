    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcApp;
    namespace Test.MvcApp
    {
        public class SampleClass
        {
            [Nullify]
            public string Name { get; set; }
            public int Age { get; set; }
        }
        [TestClass]
        public class PropertyNullifierTest
        {
            [TestMethod]
            public void TestMethod1()
            {
                SampleClass sampleObject = new SampleClass
                {
                    Name = "John Smith",
                    Age = 22,
                };
                SampleClass nullified = PropertyNullifier.Nullify(sampleObject);
                Assert.IsNull(nullified.Name);
                Assert.AreEqual(sampleObject.Age, nullified.Age);
            }
        }
    }
