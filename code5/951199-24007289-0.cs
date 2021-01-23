    var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
    var task = Task.Factory.StartNew(() =>
    {
        //Your database call here, which will be run in threadpool thread
        return resultFromDatabase;
    }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
    task.ContinueWith(antecedent =>
    {
        var resultFromDatabase = antecedent.Result;//This runs in main thread
        //Update UI
    }, CancellationToken.None, TaskContinuationOptions.None, uiContext);
