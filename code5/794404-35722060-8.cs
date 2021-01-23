        public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole() 
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }
        // Add any custom Role properties/code here
    }
    // Must be expressed in terms of our custom types:
    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser, ApplicationRole, 
        string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        // Add additional items here as needed
    }
