    var cancellationTokenSource = new CancellationTokenSource();
    var tasks = new List<Task>();
    var firstTask = new Task(FirstMethod);
    firstTask.ContinueWith(t =>
        {
            Console.WriteLine("First task exception: {0}", t.Exception);
            cancellationTokenSource.Cancel();
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    tasks.Add(firstTask);
    firstTask.Start();
    var secondTask = new Task(SecondMethod);
    secondTask.ContinueWith(t =>
        {
            Console.WriteLine("Second task exception: {0}", t.Exception);
            cancellationTokenSource.Cancel();
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    tasks.Add(secondTask);
    secondTask.Start();
    try
    {
        var cancellationToken = cancellationTokenSource.Token;
        var tasksArray = tasks.ToArray();
        Task.WaitAll(tasksArray, cancellationToken);
    }
    catch (Exception e)
    {
        // ...
    }
