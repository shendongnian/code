     public class ProductCategoryXrefMap : EntityTypeConfiguration<ProductCategoryXref>
     {
          ProductCategoryXrefMap()
          {
               HasKey(pk => new { pk.ProductId, pk.CategoryId });
               HasRequired(p => p.Product).WithMany(p => p.AssociatedCategories).HasForeignKey(fk => fk.ProductId);
               HasRequired(p => p.Category).WithMany(p => p.AssociatedProducts).HasForeignKey(fk => fk.CategoryId);
               ToTable("ProductCategoryXref");
          }
     }
