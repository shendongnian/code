    public void AddLolCat(int userId)
    {
        // I add here some text in front of the number, because I see its an integer
        //  so its better to make it a little more complex to avoid conflicts
    	var gl = new MyNamedLock("SiteName." + userId.ToString());
    	try
    	{
    		//Enter lock
    		if (gl.enterLockWithTimeout())
    		{
    			var user = _Db.Users.ById(userId);    
    			user.LolCats.Add( new LolCat() );    
    			user.LolCatCount = user.LolCats.Count();    
    			_Db.SaveChanges();
    		}
    		else
    		{
    			// log the error
    			throw new Exception("Failed to enter lock");
    		}
    	}
    	finally
    	{
    		//Leave lock
    		gl.leaveLock();
    	}
    }
