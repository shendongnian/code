     protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
     {
            modelBuilder.Entity<ProductAccessoryLink>().HasKey(i => new { i.ProductId, i.AccesoryId});
            modelBuilder.Entity<ProductAccessoryLink>()
              .HasRequired(i => i.Product)
              .WithMany(k => k.ProductAccessoryLinks)
              .HasForeignKey(i=>i.ProductId);
            modelBuilder.Entity<ProductAccessoryLink>()
              .HasRequired(i => i.Accesory)
              .WithMany(k => k.ProductAccessoryLinks)
              .HasForeignKey(i=>i.AccesoryId);
            modelBuilder.Entity<ProductAccessoryLink>()
              .HasRequired(i => i.Type)
              .WithMany()
              .HasForeignKey(i=>i.TypeId);
     }
