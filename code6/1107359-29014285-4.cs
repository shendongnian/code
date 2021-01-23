    static async Task DoSomething()
    {
        CallContext.LogicalSetData("hello", "world");
        await Task.Run(() =>
            Console.WriteLine(new
            {
                Place = "Task.Run",
                Id = Thread.CurrentThread.ManagedThreadId,
                Msg = CallContext.LogicalGetData("hello")
            }));
    }
