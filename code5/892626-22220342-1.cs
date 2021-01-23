    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    modelBuilder.Entity<order>()
    .HasRequired(c => c.Deliveryplace)
    .WithMany()
    .WillCascadeOnDelete(false);
    
    modelBuilder.Entity<order>()
    .HasRequired(c => c.Invoiceplace)
    .WithMany()
    .WillCascadeOnDelete(false);
    }
