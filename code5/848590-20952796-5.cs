    static Task<ObservableCollection<MyResult>> GetMyDataAsync(Params p)
    {
        var tcs = new TaskCompletionSource<ObservableCollection<MyResult>>();
        DoStuffClass stuff = new DoStuffClass();
        stuff.LoadCompleted += (args) => tcs.TrySetResult(args.Result);
        stuff.LongDrawOutProcessAsync(p);
        return tcs.Task;
    }
