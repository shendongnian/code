    public SomeClass()
    {
        var func = new Func<int, int, int>((i1, i2) => i1 + i2);
        Task.Factory.StartNew(() => 
            Debug.WriteLine(func(1, 2)), TaskCreationOptions.LongRunning);
        Task.Factory.StartNew(() => 
            Debug.WriteLine(DoWork(2, 3).Result), TaskCreationOptions.LongRunning);
    }
    private static Task<int> DoWork(int a, int b)
    {
        return Task.FromResult(a + b);
    }
