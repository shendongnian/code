    public class DataContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DataContext() : base("DefaultConnection"){}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRoles", "Security");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogins", "Security");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaims", "Security");
            modelBuilder.Entity<CustomRole>().ToTable("Roles", "Security");
            modelBuilder.Entity<User>().ToTable("Users", "Security");
        }
    }
