    public override string[] GetRolesForUser(string username)
    {
        var roleNames = 
            db.UserRole
                .Where(x => x.UserName.Equals(username, 
                    StringComparison.CurrentCultureIgnoreCase))
                .Select(x => x.RoleName);
        
        if (roleNames.Count() > 0)
            return roleNames.ToArray();
        else
            return new string[] { }; ;
     }
