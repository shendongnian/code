    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
                    .HasRequired(e => e.ProductBinaryData)
                    .WithRequiredPrincipal();
            
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<ProductBinaryData>().ToTable("Products");
    }
