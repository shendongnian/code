    Task<int> task = null;
    try
    {
        task = Task.Run(() => 5, new CancellationToken(true));
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("Unreachable code");
    }
    try
    {
        int result = await task;
    }
    catch (TaskCanceledException)
    {
        Console.WriteLine("Awaiting a canceled task");
    }
