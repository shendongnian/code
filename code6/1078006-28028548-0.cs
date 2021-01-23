    var tcs = new TaskCompletionSource<bool>();
    _keepAliveTask = tcs.Task;
    var waitTask = Task.Run(async () => await _keepAliveTask);
    Thread.Sleep(1000);
    Console.WriteLine(waitTask.IsCompleted);
    tcs.SetResult(true);
    Thread.Sleep(1000);
    Console.WriteLine(waitTask.IsCompleted);
