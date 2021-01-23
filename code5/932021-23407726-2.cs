    public void CreateUser(MyUser myUser)
    {
        var role = RoleManager.FindByName(myUser.RoleName);
        if (role == null) {
            role = new IdentityRole(myUser.RoleName);
            var roleresult = RoleManager.Create(role);
        }
        var user = UserManager.FindByName(myUser.Name);
        if (user == null) {
            user = new ApplicationUser { UserName = myUser.Name, Email = myUser.Name };
            var result = UserManager.Create(user, myUser.Password);
            result = UserManager.SetLockoutEnabled(user.Id, false);
        }
        // Add user admin to Role Admin if not already added
        var rolesForUser = UserManager.GetRoles(user.Id);
        if (!rolesForUser.Contains(role.Name)) {
            var result = UserManager.AddToRole(user.Id, role.Name);
        }
    }
