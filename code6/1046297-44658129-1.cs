    public class MyDbContext : DbContext, IMyDbContext
	{
        ...
		public TEntity UpdateGraph<TEntity>(TEntity entity, Expression<Func<IUpdateConfiguration<TEntity>, object>> mapping = null) where TEntity : class, new()
		{
			return ((DbContext)this).UpdateGraph(entity, mapping);
		}
	}
