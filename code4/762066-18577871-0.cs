    private static async Task Task1(Task task)
    {
        await task;
        Console.WriteLine("Task1, thread: {0}", Thread.CurrentThread.ManagedThreadId);
    }
    private static async Task Task2(Task task)
    {
        await task;
        Console.WriteLine("Task2, thread: {0}", Thread.CurrentThread.ManagedThreadId);
    }
    private static async Task Test1()
    {
        var task = Task.Delay(1000);
        var task1 = Task1(task);
        var task2 = Task2(task);
        await Task.WhenAll(task1, task2);
    }
