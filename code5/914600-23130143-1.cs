    public class MadLabsDatabaseContext : IdentityDbContext<User>
    {
        // This is the offending line
        // Add throwIfV1Schema: false
        public MadLabsDatabaseContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<IdentityUser>()
               .ToTable("AspNetUsers");
            modelBuilder.Entity<User>()
               .ToTable("AspNetUsers");
        }
    }
