    public Task DoSomethingAsync()
    {
        var t1 = DoTaskAsync("t2.1", 3000);
        var t2 = DoTaskAsync("t2.2", 2000);
        var t3 = DoTaskAsync("t2.3", 1000);
        return Task.WhenAll(t1, t2, t3);
    }
