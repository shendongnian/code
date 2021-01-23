    public class ApplicationDbContext 
        : IdentityDbContext
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
