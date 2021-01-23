    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("AuthenticationConnectionString")
        {
        }
    
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    	...
    }
