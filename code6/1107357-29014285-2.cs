    static Task DoSomething()
    {
        using (CallContextScope.Start("hello", "world"))
        {
            return Task.Factory.StartNew(() =>
                Debug.WriteLine(new
                {
                    Place = "Task.Run",
                    Id = Thread.CurrentThread.ManagedThreadId,
                    Msg = CallContext.LogicalGetData("hello")
                }));
        }
    }
