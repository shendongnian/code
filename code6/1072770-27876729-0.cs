        public class Repository<T> : IRepository<T> where T : class, IEntity
    	{
    		...
    		public virtual T GetOne(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includeProperties = null)
    		{
    			var set = SetWithIncludes(includeProperties);
    			return predicate != null ? set.FirstOrDefault(predicate) : set.FirstOrDefault();
    		}
            protected IQueryable<T> SetWithIncludes(IEnumerable<Expression<Func<T, object>>> includes)
    		{
    			IQueryable<T> set = DbSet;
    
    			if (includes != null)
    			{
    				foreach (var include in includes)
    				{
    					set = set.Include(include);
    				}
    			}
    
    			return set;
    		}
    	}
