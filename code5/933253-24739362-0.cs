    public class ApplicationUser : IdentityUser
    {
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("YourContextName")
        {
        }
    }
