    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityTwo>()
            .HasRequired(et => et.EntityOne)
            .WithOptional(eo=>eo.EntityTwo);
    }
