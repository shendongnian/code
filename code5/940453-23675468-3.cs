    try
    {
        var user = GetSingleOrDefault(Users, e => e.Id == 1);
        var profile = GetSingleOrDefault(UserProfiles, e => e.Id == 1);
        var profile2 = GetSingleOrDefault(UserProfiles, e => e.Id == 1);
        // work with user, profile and profile2
    }
    catch(InvalidOperationException ex)
    {
        Log(ex);
    }
