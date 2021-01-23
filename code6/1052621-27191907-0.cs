    internal class MyContext : SynchronizationContext
    {
    }
    [TestMethod]
    public void TestMethod1()
    {
        // Create new sync context for unit test
        SynchronizationContext.SetSynchronizationContext(new MyContext());
        var waitHandle = new ManualResetEvent(false);
        var doer = new DoSomethinger();
        //Uncommenting this line causes the ContinueWith part of the Task
        //below never to execute.
        var f = new Form();
        doer.DoSomethingAsync(() => waitHandle.Set());
        Assert.IsTrue(waitHandle.WaitOne(10000), "Wait timeout exceeded.");
    }
