        public IEnumerable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
          using(var context = new DataEntities())
          {
                  return null != predicate
                        ? context.Set<T>().Where(predicate).AsEnumerable()
                        : context.Set<T>().AsEnumerable();
          }
        }
