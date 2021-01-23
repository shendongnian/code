    public static Task<T> Start<T>(Func<T> func,
          int intervalInMilliseconds = Timeout.Infinite,
          int delayInMilliseconds = 0,
          int duration = Timeout.Infinite,
          int maxIterations = -1,
          bool synchronous = false,
          CancellationToken cancelToken = new CancellationToken(),
          TaskCreationOptions periodicTaskCreationOptions = TaskCreationOptions.None)
        {
    Task<string> task = PeriodicTaskFactory.Start(LongRunningOperation, intervalInMilliseconds: 1000, synchronous: false, cancelToken: cancellationTokenSource.Token);
    
    string result = task.Result;
    
