    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<SomeEntity> Entities { get; set; } // Your business entities
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    }
