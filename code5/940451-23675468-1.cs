    try
    {
        User user;
        UserProfile profile;
        UserProfile profile2;
        try
        {
            user = Users.SingleOrDefault(e => e.Id == 1);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("User lookup for Id = 1 failed", ex);
        }
        try
        {
            profile = UserProfiles.SingleOrDefault(e => e.Id == 1);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("User profile lookup for Id = 1 failed", ex);
        }
        try
        {
            profile2 = UserProfiles.SingleOrDefault(e => e.Id == 1);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("User profile lookup for Id = 2 failed", ex);
        }
        // work with user, profile and profile2
    }
    catch(InvalidOperationException ex)
    {
        Log(ex);
    }
