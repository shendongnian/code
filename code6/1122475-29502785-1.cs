    public static Task MethodOneAsync()
    {
        DoSomeWork1();
        var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
        var resultTask = MethodTwoAsync();
        return resultTask.ContinueWith((task) =>
        {
            syncContext.Post((state) =>
            {
                SynchronizationContext.SetSynchronizationContext(syncContext);
                DoOtherWork1();
            }, null);
        });
    }
    public static Task MethodTwoAsync()
    {
        DoSomeWork2();
        var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
        var resultTask = MethodThreeAsync();
        return resultTask.ContinueWith((task) =>
        {
            syncContext.Post((state) =>
            {
                SynchronizationContext.SetSynchronizationContext(syncContext);
                DoOtherWork2();
            }, null);
        });
    }
    public static Task MethodThreeAsync()
    {
        DoSomeWork3();
        var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
        var resultTask = DoDbWorkAsync();
        return resultTask.ContinueWith((task) =>
        {
            syncContext.Post((state) =>
            {
                SynchronizationContext.SetSynchronizationContext(syncContext);
                DoOtherWork3();
            }, null);
        });
    }.
