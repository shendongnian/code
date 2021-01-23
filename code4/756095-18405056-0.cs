    internal class UnitTest
    {
        [Fact]
        public TestDbInterface()
        {
            var someClass = new SomeClass(new MockedSomeOtherClass())
    
            var result = someClass.SomeMethod()
    
            Assert.AreEqual("42", result);
        }
    }
