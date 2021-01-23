    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<SomeEntity> Entities { get; set; }
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    }
