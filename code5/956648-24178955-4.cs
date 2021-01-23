    private Task ConnectAsync(DataFeed feed)
    {
        var tcs = new TaskCompletionSource<object>();
        feed.OnConnected += _ => tcs.TrySetResult(null);
        feed.BeginConnect();
        return tcs.Task;
    }
    
    private Task LoginAsync(DataFeed feed, string user, string password)
    {
        var tcs = new TaskCompletionSource<object>();
        feed.OnReady += _ => tcs.TrySetResult(null);
        feed.BeginLogin(user, pass);
        return tcs.Task;
    }
