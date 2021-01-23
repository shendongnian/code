    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
		protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!RoleManager.RoleExists("admim"))
            {
                var roleresult = RoleManager.Create(new IdentityRole(Administrador));
            }
            //Create User=Admin with password=123456
            var user = new ApplicationUser();
            user.UserName = "sysadmin";
            var adminresult = UserManager.Create(user, "123456");
            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, "admin");
            }
        }
     }
