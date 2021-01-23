     public class SomeClass
        {
          public ISomeInterface someInterface{get;set;}
            
            public string DoTheCall()
            {
               return someInterface.ReturnSomeString();
            }
        }
    [TestClass]
        public class Test
        {
            [TestMethod]
            public void SomeTest()
            {
                var mock = new ISomeInterface();
                mock.Setup(x => x.ReturnSomeString()).Returns("Hello World!!!");            
        
                SomeClass sc = new SomeClass {someInterface = mock.Object};
        
                Assert.IsTrue(sc.ReturnSomeString(), "Hello World!!!");
            }
        }
