    var userProfilesResult = new List<PersonProperties>(); //for storing user profiles
    foreach (var user in siteUsers)
    {
       var userProfile = peopleManager.GetPropertiesFor(user.LoginName);
       context.Load(userProfile);
       userProfilesResult.Add(userProfile);
    }
    context.ExecuteQuery();  //submit a single request 
