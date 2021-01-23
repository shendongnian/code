	public Task<UserInfo> KickOffWarmUpCache(string id)
	{
		
		//If Status = Progress
		if (cache.Get(id).Status == "Progress")
		{
            var ret = new TaskCompletionSource<UserInfo>();
			NotifyOnceCacheIsUpdated(id,(result)=>
			{
				ret.SetResult(result.userInfo);
			});
		    return ret.Task;
		}
	
		//This needs to wait for until callback is triggered and userInfo is populated
        return Task.FromResult(new UserInfo());
	}
