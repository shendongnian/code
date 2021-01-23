    // naturally synchronous, so don't use "async"
    static int DoLongWork(string param)
    {
        Console.WriteLine("Long Running Work is starting");
        Thread.Sleep(3000); // Simulating long work.
        Console.WriteLine("Long Running Work is ending");
        return 0;
    }
    static async Task<int> FooAsync(string param)
    {
        Task<int> lwAsync = Task.Run(() => DoLongWork(param));
        int res = await lwAsync;
        return res;
    }
