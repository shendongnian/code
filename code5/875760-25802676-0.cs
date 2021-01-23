    using System.Linq;
    using System.Linq.Expressions;
    namespace System.Data.Entity
    {
        public static class DbSetExtensions
        {
            public static TEntity FirstOrDefaultCache<TEntity>(DbSet<TEntity> queryable, Expression<Func<TEntity, bool>> condition) 
                where TEntity : class
            {
                return queryable
                    .Local.Where(condition.Compile()).FirstOrDefault() // find in local cache
                       ?? queryable.Where(condition).FirstOrDefault(); // if local cache returns null check the db
            }
        }
    }
