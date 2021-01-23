    var cancellationTokenSource = new CancellationTokenSource();
    List<Task> tasks = new List<Task>();
    var firstTask = Task.Factory.StartNew(FirstMethod);
    firstTask.ContinueWith(t =>
        {
            Console.WriteLine("First task exception: {0}", t.Exception);
            cancellationTokenSource.Cancel();
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    tasks.Add(firstTask);
    var secondTask = Task.Factory.StartNew(SecondMethod);
    secondTask.ContinueWith(t =>
        {
            Console.WriteLine("Second task exception: {0}", t.Exception);
            cancellationTokenSource.Cancel();
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    tasks.Add(secondTask);
    try
    {
        var cancellationToken = cancellationTokenSource.Token;
        Task.WaitAll(tasks.ToArray(), cancellationToken);
    }
    catch (Exception e)
    {
        // ...
    }
