    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.Entity<BaseEntity>().Property(x => x.CreateUserId).HasMaxLength(36);
        modelBuilder.Entity<BaseEntity>().Property(x => x.ModifyUserId).HasMaxLength(36);
        base.OnModelCreating(modelBuilder);
    }
