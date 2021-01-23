    public class DbContext : IdentityDbContext<User> , IDbContext
    {
        public DbContext()
            : base("CodeArtConnectionString")
        {
    
        }
    }
