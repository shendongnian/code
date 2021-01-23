    public List<DAL.OnlineList> Users
    {
    	get 
        {
            List<DAL.OnlineList> users = null;
            string CacheKey = "dal_users";
    
            users = HttpContext.Current.Cache[CacheKey];
            if ((users == null)) 
            {
                users = DAL.UserDAL.GetAllOnlineUser()
                        .OrderBy(x => x.Username).ToList();
                HttpContext.Current.Cache.Add(CacheKey, users, Nothing, 
                    DateTime.Now.AddSeconds(30), Caching.Cache.NoSlidingExpiration, 
                    CacheItemPriority.Default, null);
            }
    		
            return users;
    	}
    }
