     public class Repository<TEntity> : IRepository<TEntity> where TEntity : AbstractEntity
    {
        public List<TEntity> GetOrdered<TSortKey>(Func<TEntity, TSortKey> orderBy, int take, params string[] includePaths) 
        {
            var query = (from ent in this.Context.Set<TEntity>() select ent).IncludePaths(includePaths);
            return query.OrderBy(orderBy).Take(take).ToList();
        }
    }  
