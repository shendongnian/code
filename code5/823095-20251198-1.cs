    private class TestService : ISomeService
    {
      public bool DoSomethingReturnValue { get; set; }
      public bool DoSomething() { return DoSomethingReturnValue; }
    }
    [Test]
    public async Task TestMyMethod_TestInitialState_TestExpectedResult()
    {
      var myClass = new MyClass(new TestService { DoSomethingReturnValue = true });
      await myClass.MyMethod();
    }
    [Test]
    public async Task TestMyMethod_TestInitialState_TestFailure()
    {
      var myClass = new MyClass(new TestService { DoSomethingReturnValue = false });
      Assert.Throws(() => myClass.MyMethod()); // (I'm unsure of the exact NUnit syntax)
    }
