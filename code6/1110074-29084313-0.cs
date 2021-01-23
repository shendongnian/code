    public interface IDbContext
	{
		IDbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet Set(Type entityType);
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		int SaveChanges();
	}
