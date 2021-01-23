    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Ensemble>()
    .HasMany(a => a.EnsembleMembers)
    .WithOptional().WillCascadeOnDelete(false);
    }
