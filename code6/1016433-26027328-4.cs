    public static Task<TResult> Run<TResult>(Func<TResult> function)
    {
        return Task.Factory.StartNew(
            function, 
            CancellationToken.None, 
            TaskCreationOptions.None, 
            TaskScheduler.Default);
    }
