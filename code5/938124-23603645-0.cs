    static async Task<int> CreateMultipleTasks()
    {
        var task1 = Task.Run<int>(() => WaitForMeAsync(5000));
        var task2 = Task.Run<int>(() => WaitForMeAsync(3000));
        var task3 = Task.Run<int>(() => WaitForMeAsync(4000));
        Task.WaitAll(new Task[] { task1, task2, task3 });
        return task1.Result + task2.Result + taks3.Result;
    }
