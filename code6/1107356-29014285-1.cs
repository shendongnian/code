    static Task DoSomething()
    {
        CallContext.LogicalSetData("hello", "world");
        var result = Task.Factory.StartNew(() =>
            Debug.WriteLine(new
            {
                Place = "Task.Run",
                Id = Thread.CurrentThread.ManagedThreadId,
                Msg = CallContext.LogicalGetData("hello")
            }));
        CallContext.FreeNamedDataSlot("hello");
        return result;
    }
