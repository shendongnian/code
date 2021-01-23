    private void SeedMemberShip()
    {
        if (!WebMatrix.WebData.WebSecurity.Initialized)
            WebSecurity.InitializeDatabaseConnection(_connectionStringName, "UserProfile", "UserId", "UserName", autoCreateTables: true);
        var roles = (SimpleRoleProvider)Roles.Provider;
        var membership = (SimpleMembershipProvider)Membership.Provider;
        if (!roles.RoleExists("Admin"))
        {
            roles.CreateRole("Admin");
        }
        
        if (membership.GetUser(username, false) == null)
        {
            membership.CreateUserAndAccount(username, password);
        }
        
        if (!roles.GetRolesForUser(username).Contains("Admin"))
        {
            roles.AddUsersToRoles(new[] { username }, new[] { "Admin" });
        }
    }
