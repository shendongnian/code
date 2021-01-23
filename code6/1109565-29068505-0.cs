    using (var context = new ApplicationDbContext())
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
        
            roleManager.Create(new IdentityRole("Admin"));
        
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
        
            var user = userManager.FindByEmail("my.email@somewhere.com");
            userManager.AddToRole(user.Id, "Admin");
            context.SaveChanges();
        }
