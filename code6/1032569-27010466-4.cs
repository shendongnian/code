    public IList<Role> GetRoles(string username)
    {
        // the instance of login is loaded, still referencing some ISession
        var login = GetLoginForUser(username);
        return !login.Groups.Any()  // first iteration over Groups
             ? new List<Role>() 
             // second iteration 
             : login
                .Groups
                .SelectMany(x => x.Roles) // other iterations
                .OrderBy(x => x.DisplayName)
                .ToList();
    }
