    public class MyDbContext : DbContext
    {
        public MyDbContext ()
        {
            Database.SetInitializer<MyDbContext >(null);
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
