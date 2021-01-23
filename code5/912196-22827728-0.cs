    using System.Data.Entity;
    public class ProductContext : DbContext 
    { 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; } 
    }
