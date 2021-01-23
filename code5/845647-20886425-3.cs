    [Test]
    public void TestFoo()
    {
        var context = new TestSynchronizationContext();
        SynchronizationContext.SetSynchronizationContext(context);
        FooAsync().Wait();
        Assert.IsFalse(context.PostCalled);
    }
