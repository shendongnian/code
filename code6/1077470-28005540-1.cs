    static void Run()
    {
        List<string> IDs = new List<string>() { "a", "b", "c", "d", "e", "f" };
        Task[] tasks = new Task[IDs.Count];
        for (int i = 0; i < IDs.Count; i++)
            tasks[i] = GetDataAsync(IDs[i]);
        Task.WaitAll(tasks);    
    }
