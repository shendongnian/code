        public static void InitializeIdentityForEf(ApplicationDbContext context) {
            // var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            // var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            // Since we needed to move this class into the Domain namespace, we have to do the Owin differently
  
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
