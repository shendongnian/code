    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap() {
            HasKey(p => p.ProductId);
    
            Property(p => p.Name)
                .IsRequired();
    
            // Self referencing foreign key association 
            Property(c => c.ParentId)
                .IsOptional();
            HasOptional(x => x.Parent)
                .WithMany(x => x.ChildProducts)
                .HasForeignKey(x => x.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
