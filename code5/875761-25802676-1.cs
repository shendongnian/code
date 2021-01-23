    using System.Linq;
    using System.Linq.Expressions;
    namespace System.Data.Entity
    {
        public static class DbSetExtensions
        {
            public static TEntity FirstOrDefaultCache<TEntity>(this DbSet<TEntity> queryable, Expression<Func<TEntity, bool>> condition) 
                where TEntity : class
            {
                return queryable
                    .Local.FirstOrDefault(condition.Compile()) // find in local cache
                       ?? queryable.FirstOrDefault(condition); // if local cache returns null check the db
            }
        }
    }
