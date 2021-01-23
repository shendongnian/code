    private async void InfiniteTaskLoopExample()
    {
        var tasks = new List<Task>();
        // Start 20 tasks
        for (int i = 0; i < 20; i++)
        {
            tasks.Add(this.CreateTask());
        }
        // Define a cooldown
        var cooldown = TimeSpan.FromMinutes(5.0);
        // Start an infinite loop
        while (true)
        {
            // Wait for any of 20 tasks to complete
            var completedTask = await Task.WhenAny(tasks);
            // Reschedule the completed task
            tasks.Remove(completedTask);
            tasks.Add(Task.Delay(cooldown).ContinueWith(t => this.CreateTask()));
        }
    }
    private Task CreateTask()
    {
        throw new NotImplementedException();
    }
