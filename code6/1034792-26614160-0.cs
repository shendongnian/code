    private int CacheCheck()
    {
    	// Create the keys used and retrive the values from the cahce
    	IncrementingCacheObject cacheUsername = Cache[KeyUsername] as IncrementingCacheObject;
    	IncrementingCacheObject cacheDiffAttempts = Cache[KeyDiffAttempts] as IncrementingCacheObject;
    	IncrementingCacheObject cacheSameAttempts = Cache[KeySameAttempts] as IncrementingCacheObject;
    
    	// Check if the username exists in cache
    	if (cacheUsername != null)
    	{
    		if (cacheUsername.Username.Equals(this.txtUserName.Text, StringComparison.InvariantCultureIgnoreCase))
    		{
    			if (cacheSameAttempts != null)
    			{
    				cacheSameAttempts.Count++;
    			}
    			else
    			{
    				cacheSameAttempts = new IncrementingCacheObject { Count = 0, ExpireDate = DateTime.UtcNow.AddMinutes(1), Username = this.txtUserName.Text };
    			}
    
    			HttpContext.Current.Cache.Insert(KeySameAttempts, cacheSameAttempts, null, cacheSameAttempts.ExpireDate, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    		}
    		else
    		{
    			if (cacheDiffAttempts != null)
    			{
    				cacheDiffAttempts.Count++;
    			}
    			else
    			{
    				cacheDiffAttempts = new IncrementingCacheObject { Count = 0, ExpireDate = DateTime.UtcNow.AddMinutes(1), Username = this.txtUserName.Text };
    			}
    
    			HttpContext.Current.Cache.Insert(KeyDiffAttempts, cacheDiffAttempts, null, cacheDiffAttempts.ExpireDate, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    		}
    
    		// Set the last used username value in the Cache to the value in the text box
    		cacheUsername.Username = this.txtUserName.Text;
    	}
    	else
    	{
    		cacheUsername = new IncrementingCacheObject { Count = 0, ExpireDate = DateTime.UtcNow.AddMinutes(1), Username = this.txtUserName.Text };
    		cacheDiffAttempts = new IncrementingCacheObject { Count = 0, ExpireDate = DateTime.UtcNow.AddMinutes(1), Username = this.txtUserName.Text };
    		cacheSameAttempts = new IncrementingCacheObject { Count = 0, ExpireDate = DateTime.UtcNow.AddMinutes(1), Username = this.txtUserName.Text };
    		HttpContext.Current.Cache.Insert(KeySameAttempts, cacheSameAttempts, null, cacheSameAttempts.ExpireDate, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    		HttpContext.Current.Cache.Insert(KeyDiffAttempts, cacheDiffAttempts, null, cacheDiffAttempts.ExpireDate, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    	}
    
    	HttpContext.Current.Cache.Insert(KeyUsername, cacheUsername, null, cacheUsername.ExpireDate, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    	
    	// Check whether any log in attempts have surpassed the threshold and return a value to indicate what kind of log in was detected
    	if (cacheDiffAttempts != null && cacheDiffAttempts.Count >= MaxLogAttemptsBeforeBan)
    	{
    		return 0;
    	}
    
    	if (cacheSameAttempts != null && cacheSameAttempts.Count >= MaxLogAttemptsBeforeBan)
    	{
    		return 1;
    	}
    
    	return -1;
    }
    
    /// <summary>
    /// This will reset the cache to blank/starting values.
    /// </summary>
    private void ResetCache()
    {
    	HttpContext.Current.Cache.Remove(KeyUsername);
    	HttpContext.Current.Cache.Remove(KeySameAttempts);
    	HttpContext.Current.Cache.Remove(KeyDiffAttempts);
    }
    
    // Class used to store objects in the cache
    private class IncrementingCacheObject
    {
    	public string Username;
    	public int Count;
    	public DateTime ExpireDate;
    }
