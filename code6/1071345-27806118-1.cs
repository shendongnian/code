    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Auction>()
      .HasKey(t => t.Id)
      .Property(t => t.Id)
      .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    }
