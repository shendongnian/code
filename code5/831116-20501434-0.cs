    // TODO: this probably needs to be thread-safe
    // you can use ConcurrentDictionary for that
    Dictionary<int, TaskCompletionSource<Result>> requestTcses;
    public async Task<Result> MakeApiRequestAsync()
    {
       int id = …;
       var tcs = new TaskCompletionSource<Result>();
       requestTcses.Add(id, tcs);
       await SendRequestAsync(id);
       return await tcs.Task;
    }
    
    …
    
    var result = await MakeApiRequest();
