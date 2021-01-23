    public static void SeedAdminAccount(this IdentityContext identityContext, string username, string password)
    {
        var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(identityContext));
        userManager.UserValidator = new EmailUserValidator<IdentityUser>(userManager);
        var user = userManager.Find(username, password);
        if (user != null) return;
        SeedUserRoles(identityContext);
        user = new IdentityUser() { UserName = username };
        var result = userManager.Create(user, password);
        if (result.Succeeded)
        {
            userManager.AddToRole(user.Id, Role.Administrator);
        }
        else
        {
            var e = new Exception("Could not add default account.");
            var enumerator = result.Errors.GetEnumerator();
            foreach(var error in result.Errors)
            {
                e.Data.Add(enumerator.Current, error);
            }
            throw e;
        }
    }
    public static void SeedUserRoles(this IdentityContext identityContext)
    {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(identityContext));
        foreach(var role in Role.Roles)
        {
            var roleExists = roleManager.RoleExists(role);
            if (roleExists) continue;
            roleManager.Create(new IdentityRole(role));
        }
    }
