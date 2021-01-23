    [TestMethod]
    public void TestDoSomethingNotCalled()
    {
        var myclass = new MyClass();
        
        bool methodcalled = false;
        myclass.DoSomething = () => { methodcalled = true; };
        myclass.TryDoSomething();
        Assert.IsFalse(methodcalled);
    }
