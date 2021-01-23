    protected override void Seed(Repository.DataContext.IdentityDb context)
        var roleStore = new RoleStore<IdentityRole>(context);
        var roleManager = new RoleManager<IdentityRole>(roleStore);
        var userStore = new UserStore<ApplicationUser>(context);
        var userManager = new UserManager<ApplicationUser>(userStore);               
        var user = new ApplicationUser { UserName = "sallen" };
        userManager.Create(user, "password");                    
        roleManager.Create(new IdentityRole { Name = "admin" });
        userManager.AddToRole(user.Id, "admin");
    }
