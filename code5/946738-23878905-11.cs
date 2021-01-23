    static Task<int> DoAsync()
    {
        var tcs = new TaskCompletionSource<int>();
        ThreadPool.QueueUserWorkItem(_ => tcs.SetResult(0));
        return tcs.Task;
    }
    static void Tester(string name, Func<Task<int>, Task<int>> func)
    {
        ThreadPool.SetMinThreads(200, 200);
        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        for (int i = 0; i < 1000000; i++)
        {
            func(DoAsync()).Wait();
        }
        sw.Stop();
        Console.WriteLine("{0}: {1}ms", name, sw.ElapsedMilliseconds);
    }
