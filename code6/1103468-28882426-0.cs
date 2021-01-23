    public class DatabaseContext : IdentityDbContext<UserInfo>
    {
        public virtual DbSet<Entity> Entities { get; set; } // Your business entities
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    }
