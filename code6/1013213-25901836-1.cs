        public class EFDbContext : DbContext
        {
            public EFDbContext() : base("DatabaseName") { }
        
            public DbSet<Product> Products { get; set; }
        }
