    internal sealed class Configuration : DbMigrationsConfiguration<IBCF.Core.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    protected override void Seed(IBCF.Core.ApplicationDBContext context)
    {
        //Initialize managers
        var userManager = new UserManager<User>(new UserStore<User>(context));
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        if(userManager.FindByEmail("john.doe@email.com") == null)
        {
            //Add default system roles
            roleManager.Create(new IdentityRole("Superuser"));
            roleManager.Create(new IdentityRole("User"));
            //Add default system users
            var superuser1 = new User() { FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", UserName = "john.doe@email.com.com" };
            if (userManager.Create(superuser1, "P@ssword123").Succeeded)
            {
                userManager.AddToRole(superuser1.Id, "Superuser");
            }
        }
        context.SaveChanges();
    }
    }
