    [TestMethod]
    public void TestMethod1()
    {
        var foo = new Foo();
        var bar = new Bar();
        foo.theEvent += bar.PerformSomeTask;
        foo.OpenPage1()
        foo.OpenPage2();
        Assert.AreEqual(2, bar.Counter);
    }
