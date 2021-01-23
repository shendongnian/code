        public IEnumerable<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null)
        {
          using(var context = new DataEntities())
          {
                  return null != predicate
                        ? context.Set<T>().Where(predicate).AsEnumerable()
                        : context.Set<T>().AsEnumerable();
          }
        }
