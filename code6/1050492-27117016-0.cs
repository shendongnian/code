    TimeMethod(Func<Task> method)
    {
    
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        method().Wait();
        stopwatch.Stop();
    
        Console.WriteLine(stopwatch.ElapsedTicks);
    }
