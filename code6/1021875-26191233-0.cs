     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        modelBuilder.Entity<C3>().Property(p => p.Amount).HasColumnName("Amount");
        modelBuilder.Entity<C4>().Property(p => p.Amount).HasColumnName("Amount");
     }
