    public async Task MyMethod()
    {
        Task<int> longRunningTask = LongRunningOperation();
        MySynchronousMethod();
        longRunningTask.ContinueWith(t => part2(t.Result));
    }
    void part2(int result)
    {
        Console.WriteLine(result);
    }
