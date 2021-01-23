        public IEnumerable<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null)
        {
          using(var context = new DataEntities())
          {
            return null != predicate
                ? context.Where(predicate)
                : context.Set<TEntity>();
          }
        }
