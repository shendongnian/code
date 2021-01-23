    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {    
      modelBuilder.Entity<MyEntity>(b =>
      {
        b.Key(e => e.Identifier);
        b.Property(e => e.Identifier).ForSqlServer().UseIdentity();
      }
    }
