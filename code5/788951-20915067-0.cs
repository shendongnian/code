    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("name=DefaultConnection")
        {
        }
        //
        // These are required for the integrated user membership.
        //
        public virtual DbSet<IdentityRole> Roles { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin> UserLogins { get; set; }
        public virtual DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
