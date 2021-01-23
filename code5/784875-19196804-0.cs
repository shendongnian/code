    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 10000; i++)
    {
        int i1 = i;
        tasks.Add(Task.Run(() => Console.WriteLine(i1)));
    }
    Task.WaitAll(tasks.ToArray());
