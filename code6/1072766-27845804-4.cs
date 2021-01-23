    internal static async Task WorkAsync()
    {
        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = SumAsync();
        }
        await Task.WhenAll(tasks);
    }
    
