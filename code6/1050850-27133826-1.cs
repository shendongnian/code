    class MyTestableService : MyService
    {
        protected override string GetVariable(HttpContext fromContext, string name)
        {
            return MockedVariables[name];
        }
        public Dictionary<string, string> MockedVariables { get; set; }
    }
    [Test]
    public void TestSomeMethod()
    {
        var serviceUnderTest = 
               new MyTestableService 
               { 
                    MockedVariables = new Dictionary<string, string>
                    {
                         { "some var name", "var value" }
                    }
               };
         //more arrangements here
         Assert.AreEqual(expectedResult, serviceUnderTest.SomeMethod());
     }
