    const int InitAssertedMethodCalls = 1;
    [TestMethod]
    public void TestMethod1()
    {
        sut.TestedMethod(); 
        A.CallTo(() => myFakedObject.AssertedMethod())
                 .MustHaveHappened(Repeated.Exactly.Times(1 + InitAssertedMethodCalls )); 
    }
