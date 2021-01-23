    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
               modelBuilder.Entity<YourEntity>()
                        .Property(x => x.TheProprty)
                        .HasPrecision(18, 2);
        }
