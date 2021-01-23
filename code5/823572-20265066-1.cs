    public static Task<T>[] StartPeriodicTask<T>(
              Function<T> action,
              int intervalInMilliseconds,
              int delayInMilliseconds,
              CancellationToken cancelToken) {...}
    Task<string>[] tasks = PeriodicTaskFactory.StartPeriodicTask(LongRunningOperation, intervalInMilliseconds: 1000, synchronous: false, cancelToken: cancellationTokenSource.Token);
    
    int taskId = Task.WaitAny(tasks);
    Task<string> task = tasks[taskId];
    string result = task.Result;
    
