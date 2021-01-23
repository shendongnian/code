    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<RoleResourceActivity> RoleResourceActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Activity>().HasKey(i => i.Id);
            modelBuilder.Entity<Resource>().HasKey(i => i.Id);
            modelBuilder.Entity<User>().HasKey(i => i.Id);
            modelBuilder.Entity<RoleResourceActivity>().HasKey(i => new {
                i.ResourceId, 
                i.ActivityId, 
                i.RoleId
            });
            base.OnModelCreating(modelBuilder);
        }
        public AppDbContext() : base("AppDb") { 
            Database.SetInitializer<AppDbContext>(new AppDbContextInitializer());
        }
    }
