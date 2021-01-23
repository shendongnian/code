    public class SampleContext : DbContext
        {
            public IDbSet<Category> Categories { get; set; }
            public IDbSet<Product> Products { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                 base.OnModelCreating(modelBuilder);
            }
        }
        public class Category
        {
            [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CategoryId { get; set; }
            [Key, Column(Order = 1)]
            public int ShopId { get; set; }
            public string Name { get; set; }
        }
        public class Product 
        {
            [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ProductId { get; set; }
            public int ShopId { get; set; }
            public int CategoryId { get; set; }
            [ForeignKey("CategoryId, ShopId")]
            public virtual Category Category { get; set; }
        }
