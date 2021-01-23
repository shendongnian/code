    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }
    
        public DbSet<UserProfile> UserProfiles { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
            .HasMany<UserProfile>(r => r.UserProfiles)
            .WithMany(u => u.UserRoles)
            .Map(m =>
            {
                m.ToTable("webpages_UsersInRoles");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });
        }
    }
