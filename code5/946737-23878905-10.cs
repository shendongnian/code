    // async/await version
    static async Task<int> Test1Async(Task<int> task)
    {
        if (task.IsCompleted)
            return task.Result;
        return await task;
    }
    // TPL version
    static Task<int> Test2Async(Task<int> task)
    {
        if (task.IsCompleted)
            return Task.FromResult(task.Result);
        return task.ContinueWith(
            t => t.Result,
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);
    }
