     public class SomeClass
        {
        ISomeInterface someInterface;
            public SomeClass(ISomeInterface inter)
            {
               this.someInterface = inter;
            }
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
    
            SomeClass sc = new SomeClass(mock.Object);
    
            Assert.IsTrue(sc.ReturnSomeString(), "Hello World!!!");
        }
    }
