    protected override void Seed(ApplicationDbContext context)
            {
                context.Configuration.LazyLoadingEnabled = true;
    
                //var userManager = HttpContext.Current
                //    .GetOwinContext().GetUserManager<ApplicationUserManager>();
    
                //var roleManager = HttpContext.Current
                //    .GetOwinContext().Get<ApplicationRoleManager>();
    
                var roleStore = new RoleStore<ApplicationRole, int, ApplicationUserRole>(context);
                var roleManager = new RoleManager<ApplicationRole, int>(roleStore);
                var userStore = new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context);
                var userManager = new UserManager<ApplicationUser, int>(userStore);   
    ...
