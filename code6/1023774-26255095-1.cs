    public Repository(DbContext context)
    {
        DbContext = context;
        DbSet = context.Set<T>();
    }
}
