     public virtual T FindElement(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
     {
            T item = null;
            using (var context = new Entities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                 
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
 
                item = dbQuery
                      .FirstOrDefault(where); //Apply where clause
            }
            return item;
     }
