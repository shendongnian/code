    int count = 0;
    var tasks = Enumerable.Range(0, 10).Select(_ => 
        Task.Run(() => Interlocked.Increment(ref count)));
    // tasks = tasks.ToArray();   // deferred vs. eager execution
    Task.WaitAll(tasks.ToArray());
    Task.WaitAll(tasks.ToArray());
    Console.WriteLine(count);
