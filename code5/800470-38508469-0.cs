    protected override void Seed(AuthContext context)
    {
        const string userName = "AdminUserName";
        const string password = "AdminPassword";
        const string roleName = "AdminRole";
        const string phoneNumber = "PhoneNumber";
        var appUserStore = new UserStore<ApplicationUser>(context);
        var appUserManager = new UserManager<ApplicationUser>(appUserStore);
        var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
        try
        {
            var user = context.Users.SingleOrDefault(u => u.UserName == userName);
            var role = context.Roles.SingleOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                appRoleManager.CreateAsync(new IdentityRole(roleName)).Wait();
                role = context.Roles.SingleOrDefault(r => r.Name == roleName);
            }
            if (user == null)
            {
                appUserManager.CreateAsync(new ApplicationUser { UserName = userName, PhoneNumber = phoneNumber}, password).Wait();
                user = context.Users.SingleOrDefault(u => u.UserName == nationalCode);
            }
            var userRole = user.Roles.SingleOrDefault(r => r.RoleId == role.Id);
            if (userRole == null)
            {
                appUserManager.AddToRoleAsync(user.Id, roleName).Wait();
            }
        }
        catch (Exception ex)
        {
            // Error catched!
        }
    }
