    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>()
            .HasMany(e => e.Restrictions)
            .WithRequired(e => e.Asset)
            .WillCascadeOnDelete(false);
    
        modelBuilder.Entity<Asset>()
            .HasMany(e => e.Segments)
            .WithRequired(e => e.Asset)
            .WillCascadeOnDelete(false);
    
        modelBuilder.Entity<Segment>()
            .HasMany(e => e.Restrictions)
            .WithRequired(e => e.Segment)
            .WillCascadeOnDelete(false);
    }
