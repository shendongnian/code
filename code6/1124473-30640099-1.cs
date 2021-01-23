    public Task SetEmailConfirmedAsync(User user, bool confirmed)
    {            
	    user.Verified = confirmed;
    	return Task.FromResult(0);
    }
