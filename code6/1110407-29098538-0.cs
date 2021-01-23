        ApplicationDbContext userscontext = new ApplicationDbContext();
        var userStore = new UserStore<ApplicationUser>(userscontext);
        var userManager = new UserManager<ApplicationUser>(userStore);
        var roleStore = new RoleStore<IdentityRole>(userscontext);
        var roleManager = new RoleManager<IdentityRole>(roleStore);
        // Create Role
        if (!roleManager.RoleExists("Admin"))
        { 
            roleManager.Create(new IdentityRole("Admin"));
        }
        if(!userscontext.Users.Any(x=> x.UserName=="marktest"))
        {
            // Create User
            var user = new ApplicationUser { UserName = "marktest", Email = "marktest@gmail.com" };
            userManager.Create(user, "Pa$$W0rD!");
            // Add User To Role
            if (!userManager.IsInRole(user.Id, "Admin"))
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
        }
