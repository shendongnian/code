    private static readonly Lazy<int> _tasksResult = new Lazy<int>(
        () => InitTest());
    static int InitTest()
    {
        var taskList = new List<Task>();
        for (int i = 0; i < 100; i++)
            taskList.Add(Task.Run(() => Foo()));
        return Task.WhenAll(taskList.ToArray()).GetAwaiter().GetResult();
    }
