    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
           modelBuilder.Entity<Product>() // one-to-one
               .ToTable("Products")
               .HasKey(e => e.Id)
               .HasRequired(e => e.Info)
               .WithRequiredDependent(e => e.Product);
        
           modelBuilder.Entity<ProductInfo>() // map to the same table Products
               .ToTable("Products")
               .HasKey(e => e.Id);
        
           //add this code
           modelBuilder.Entity<Product>()
                .HasRequired(p => p.Photo) // "Photo"  defined in Product class for ProductPhoto class's object name
                .WithRequiredPrincipal(c => c.Product);// "Product"  defined in ProductPhoto class for Product's class object name
        
                base.OnModelCreating(modelBuilder);
    }
