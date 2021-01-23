    static async Task MainAsync(String[] args) {
    
        List<Task> tasks = new List<Task>();
        for (int i = 1; i <= 1000; i++)
            tasks.Add(DoSomethingAsync2(i)); // Can replace with any version
        await Task.WhenAll(tasks);
    }
