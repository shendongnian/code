    public class DatabaseContext : IdentityDbContext<UserInfo>
    {
        public virtual DbSet<Comment> Comments { get; set; } // Your business entities
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    }
