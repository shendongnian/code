        protected override void Seed(MovieDb context)
        {            
        //context.Movies.AddOrUpdate(...);
    
        // ...
    
            SeedMembership();
        }
    
        private void SeedMembership()
        {            
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
     
        var roles = (SimpleRoleProvider) Roles.Provider;
        var membership = (SimpleMembershipProvider) Membership.Provider;
     
        if (!roles.RoleExists("Admin"))
        {
            roles.CreateRole("Admin");
        }
        if (membership.GetUser("sallen",false) == null)
        {
            membership.CreateUserAndAccount("sallen", "imalittleteapot");
        }
        if (!roles.GetRolesForUser("sallen").Contains("Admin"))
        {
            roles.AddUsersToRoles(new[] {"sallen"}, new[] {"admin"});
        }
    }
