    public class MyDbContext : DbContext
        {
        public DbSet<User> Users { get; set; }
        .
        .
        .
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
             modelBuilder.Configurations.Add(new UserMap());
        }
    }
