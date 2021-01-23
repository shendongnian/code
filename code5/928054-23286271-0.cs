    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
...
    modelBuilder.Entity<Cart>()
        .HasMany(c => c.Products)
        .WithMany()
        .Map(m =>
        {
            m.MapLeftKey("CartId");
            m.MapRightKey("ProductID");
            m.ToTable("CartProducts");
        });
