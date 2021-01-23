    public class MyDbContext : DbContext
    {
        public MyDbContext ()
        {
            Database.SetInitializer<MyDbContext >(null);
        }
        public DbSet<Users> Users { get; set; }    
    }
