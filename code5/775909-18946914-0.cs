    public class ProductContext : DbContext
    {
        public DbSet<Category> TblCategories { get; set; }
        public DbSet<Product> TblProduct { get; set; }
    }
