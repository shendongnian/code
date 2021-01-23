    public Task<ActionResult> Index()
    {
        var tcs = new TaskCompletionSource<ActionResult>();
        GetAreas().ContinueWith(t => 
        {
          if(t.IsCancelled)
            tcs.SetCancelled();
          else if(t.IsFaulted)
            tcs.SetException(t.Exception);
          else
            tcs.SetResult(new View(model: t.Result); 
        });
        return tcs.Task;
    }
