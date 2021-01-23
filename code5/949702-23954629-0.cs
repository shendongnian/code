    var result = new List<BOTNET_Website_User>();
    foreach (var user in allUsers)
    {
        if (user.BONET_Permissions == "R")
        {
            result.Add(user);
        }
    }
