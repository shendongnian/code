    List<Task> tasks = new List<Task>();
    
    for (int i=0; i<10; i++)
    {
        tasks.Add(Task.Factory.StartNew(() => DoSomething());
    }
    Task.WaitAll(tasks);
