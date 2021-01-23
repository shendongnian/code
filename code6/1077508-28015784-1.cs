    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasRequired(c => c.Card)
                                       .WithRequiredPrincipal();
        modelBuilder.Entity<Card>().HasKey(c => c.CustomerId);
    }
