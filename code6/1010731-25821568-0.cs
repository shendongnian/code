    public class MyDBContext : DbContext
    {
        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
