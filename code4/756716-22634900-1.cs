    public static EntityTypeConfiguration<TEntity> Entity<TEntity>(this DbModelBuilder modelBuilder, Action<EntityTypeConfiguration<TEntity>> action) where TEntity : class
    {
        var r = modelBuilder.Entity<TEntity>();
        action(r);
        return r;
    }
