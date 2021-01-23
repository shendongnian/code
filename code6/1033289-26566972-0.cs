        [TestClass]
        public class FooTestUnit
        {
            [TestMethod]
            public void TestFooBarProperty () {
                int referenceValue = 42;
                int actualValue = methodToTest();
                Assert.AreEqual(referenceValue, actualValue);
            }
        }
    }  
