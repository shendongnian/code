    public Task<bool> FetchData()
    {
    	var tcs = new TaskCompletionSource<bool>();
        Task.Run(() => {
        	var dal=_bll.WarmUp(ID);    
        	tcs.SetResult(dal != null);
        });
        
        return tcs.Task.Result;
    }
