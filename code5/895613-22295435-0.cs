    // Wait for all tasks to complete.
    Task[] tasks = new Task[10];
    for (int i = 0; i < 10; i++)
    {
       tasks[i] = Task.Factory.StartNew(() => DoSomeWork(10000000));
    }
    Task.WaitAll(tasks);
