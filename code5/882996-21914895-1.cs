    [TestClass]
    public class Test
    {
        [TestMethod]
        public void SomeTest()
        {
            var mock = new Mock<ISomeInterface>();
            mock.Setup(x => x.ReturnSomeString()).Returns("Hello World!!!");            
    
            SomeClass sc = new SomeClass(mock.Object);
    
            Assert.IsTrue(sc.ReturnSomeString(), "Hello World!!!");
        }
    }
