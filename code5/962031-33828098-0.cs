    public async Task<Result> AssingUserManager(string userUpn, string managerUpn)
    {
    	try
    	{
    		var user = (AD.User)await ADClient.Users
    			.Where(x => x.UserPrincipalName == userUpn)
    			.ExecuteSingleAsync();
    
    		var manager = (AD.User)await ADClient.Users
    			.Where(x => x.UserPrincipalName == managerUpn)
    			.ExecuteSingleAsync();
    
    		user.Manager = manager;
    
    		await manager.UpdateAsync();
    		return Result.Ok();
    	}
    	catch (Exception ex)
    	{
    		return Result.Fail(new Error("Failed to assign manager", null, ex));
    	}
    }
    
    public async Task<Result<User>> GetUserManager(string upn)
    {
    	try
    	{
    		var user = (AD.User)await ADClient.Users
    					.Where(x => x.UserPrincipalName == upn)
    					.Expand(x => x.Manager)
    					.ExecuteSingleAsync();
    
    		var manager = user.Manager as AD.User;
    		if (manager != null)
    		{
    			return Result.Ok(ConvertToModel(manager));
    		}
    
    		return Result.Fail<User>(new Error("Manager not found for specified user", null));
    	}
    	catch (Exception ex)
    	{
    		return Result.Fail<User>(new Error("Failed to get user's manager", null, ex));
    	}
    }
