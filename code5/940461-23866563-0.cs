    public void GetSingleOrDefaultTest()
    {
        try
        {
            Logger.Debug("Getting user with id = {0}", 1);
            var user = Users.SingleOrDefault(e => e.Id == 1);
    
            Logger.Debug("Getting user profile with id = {0}", 1);
            var profile = UserProfiles.SingleOrDefault(e => e.Id == 1);
    
            Logger.Debug("Getting user profile with id = {0}", 2);
            var profile2 = UserProfiles.SingleOrDefault(e => e.Id == 2);
        } 
        catch(Exception ex)
        {
            Logger.ErrorException("Failed getting single or default", ex);
        }
    }
