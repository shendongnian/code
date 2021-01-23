    [TestClass]
    public void MyTestClass
    {
        public TestContext TestContext { get; set; }
    
        [TestMethod]
        public void MyTestMethod()
        {
            Guid guid = ...;
            Something something = Foo.GetSomething(guid);
        }
    }
