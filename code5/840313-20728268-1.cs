     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
          modelBuilder.Entity<ContentType>()
                .HasMany(c => c.Children)
                .WithOptional(c => c.Parent)
                .HasForeignKey(c => c.ParentId);
        base.OnModelCreating(modelBuilder);
    
     }
