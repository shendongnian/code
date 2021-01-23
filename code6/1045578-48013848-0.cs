    public class ProductContext : DbContext, IDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base((DbContextOptions)options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
        public DbSet<Entities.Product> Products { get; set; }
    }
