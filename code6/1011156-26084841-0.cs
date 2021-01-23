    modelBuilder.Entity<Product>()
        .HasMany(x => x.Clients)
        .WithMany(x => x.Products)
    .Map(x =>
    {
        x.ToTable("UserPriceList"); // third table is named Cookbooks
        x.MapLeftKey("ProductId");
        x.MapRightKey("ClientId");
    });
