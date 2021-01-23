    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasMany(p => p.ProductArticles)
                .WithRequired(a => a.Product)
                .HasForeignKey(a => a.ProductId);
        }
    }
    public class ProductArticleMap : EntityTypeConfiguration<ProductArticle>
    {
        public ProductArticleMap()
        {
            ToTable("ProductArticle");
        }
    }
