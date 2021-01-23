	public Task<UserInfo> KickOffWarmUpCache(string id)
	{
		
		//If Status = Progress
		if (cache.Get(id).Status == "Progress")
		{
            var ret = new TaskCompletionSource<UserInfo>();
			NotifyOnceCacheIsUpdated(id,(result)=>
			{
                //complete the task.
				ret.SetResult(result.userInfo);
			});
            //return a Task...which the SetResult will complete.
		    return ret.Task;
		}
	
		//Return a result synchronously
        return Task.FromResult(new UserInfo());
	}
