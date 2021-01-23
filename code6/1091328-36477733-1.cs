    private Task<string> GetOnlineUsersAsync()
    {
        var tcs = new TaskCompletionSource<string>();
        _pubnub.HereNow<string>(MainChannel,
            res => tcs.SetResult(res),
            err => tcs.SetException(new Exception(err.Message)));
        return  tcs.Task; 
    }
    // using
    var users = await GetOnlineUsersAsync();
