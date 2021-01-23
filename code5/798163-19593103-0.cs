    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 10; i++)
    {
        int capture = i;
        tasks.add(Task.Factory.StartNew(() => DoSomething(capture)));
    }
    Task.WaitAll(tasks.ToArray());
