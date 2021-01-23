    [TestMethod]
    public void TestDoSomethingCalled()
    {
        var myclass = new MyClass();
        
        bool methodcalled = false;
        myclass.DoSomething = () => { methodcalled = true; };
        myclass.TryDoSomething();
        Assert.IsTrue(methodcalled);
    }
    [TestMethod]
    public void TestDoSomethingNotCalled()
    {
        var myclass = new MyClass();
        AssertDoesNotThrow<NullReferenceException>(
            () => { myclass.TryDoSomething(); });
    }
