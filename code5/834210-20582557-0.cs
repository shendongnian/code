    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Product>()
                .Map<Dress>(m => m.Requires("ProductCategoryID").HasValue(1))
                .Map<Shoes>(m => m.Requires("ProductCategoryID").HasValue(2));
    }
