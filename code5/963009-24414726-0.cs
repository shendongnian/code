	public override Task<IdentityResult> ValidateAsync(AppUser item)
	{
		var result = new IdentityResult();
		var tcs = new TaskCompletionSource<IdentityResult>();
		if(item.Email != "a@a.com")
		{
			IEnumerable<string> errors = new List<string>() { "error1" };
			result.Add(errors)
		}   
		tcs.SetResult(result);        
		return tcs.Task;
	}
