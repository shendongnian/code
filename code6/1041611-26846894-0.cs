     modelBuilder.Entity<Lookup>().Map<Catalog>(m => m.Requires("IsCatalog").HasValue(true));
     modelBuilder.Entity<Lookup>().Map<CatalogType>(m =>m.Requires("IsCatalog").HasValue(false));
     context.Lookups.AddOrUpdate(p => new { p.Name , p.IsCatalog},
            new CatalogType
            {
                Name = "General",
                IsActive = true,
                Order = 1,
            },
            new CatalogType
            {
                Name = "Custom",
                IsActive = true,
                Order = 2,
            });
            //context.SaveChanges(); //if you used base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder); // then you don't need to save
