    public static Task<T> StartPeriodicTask<T>(
              Function<T> action,
              int intervalInMilliseconds,
              int delayInMilliseconds,
              CancellationToken cancelToken) {...}
    Task<string> task = PeriodicTaskFactory.StartPeriodicTask(LongRunningOperation, intervalInMilliseconds: 1000, synchronous: false, cancelToken: cancellationTokenSource.Token);
    
    string result = task.Result;
    
