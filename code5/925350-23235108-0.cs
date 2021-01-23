    public override void Run()
    {
        var tasks = new List<Task>();
        tasks.Add(RunTask1Async());
        tasks.Add(RunTask2Async());
        tasks.Add(RunTask3Async());
        Task.WaitAll(tasks.ToArray());
    }
