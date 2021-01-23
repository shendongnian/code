    class GenericRepository<T> : IRepository<T> where T : class
        {
           public IList<T> GetItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
           {
               List<T> list;
               using(var ctx = new Context())
               {
                   var query = ctx.Set<T>().AsQueryable();
    
                   foreach (string navigationProperty in navigationProperties)
                        query = query.Include(navigationProperty);//got to reaffect it.
    
                   list = query.Where(predicate).ToList<T>();
               }
               return list;
           } 
        }
