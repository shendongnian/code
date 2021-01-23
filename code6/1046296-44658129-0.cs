    public interface IMyDbContext
    {
        ...
        TEntity UpdateGraph<TEntity>(TEntity entity, Expression<Func<IUpdateConfiguration<TEntity>, object>> mapping = null) where TEntity : class, new();
    }
