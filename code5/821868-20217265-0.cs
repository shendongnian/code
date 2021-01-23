    public Task<bool> FetchData()
    {
    	var tcs = new TaskCompletionSource<bool>();
        var dal=_bll.WarmUp(ID);    
        tcs.SetResult(dal != null);
        return tcs.Task.Result;
    }
