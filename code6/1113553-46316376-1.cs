    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
       modelBuilder.Entity<AbstractBase>();
       modelBuilder.Entity<Concrete1>();
       modelBuilder.Entity<Concrete2>();
    }
