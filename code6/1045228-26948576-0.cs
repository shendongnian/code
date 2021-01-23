    private IDictionary<Type, string> _primaryKeyCache = new Dictionary<Type, string>();
    
    public IQueryable<T> GetRecords(int[] keys)
    {
       var dbSet = context.Set<T>();
    
       var type = typeof(T);
    
       string primaryKeyName;
       if(!_primaryKeyCache.TryGetValue(type, out primaryKeyName)){
          var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
          var set = objectContext.CreateObjectSet<YourEntity>();
          var keyName = set.EntitySet.ElementType
                                                .KeyMembers
                                                .Select(k => k.Name)
    											.First();
    
          _primaryKeyCache[type] = primaryKeyName = keyName;
       }
       return dbSet.DynamicContains(primaryKeyName, keys);
    }
    private static IQueryable<T> DynamicContains<T, TProperty>(
            this IQueryable<T> query, 
            string property, 
            IEnumerable<TProperty> items)
        {
            var pe = Expression.Parameter(typeof(T));
            var me = Expression.Property(pe, property);
            var ce = Expression.Constant(items); 
            var call = Expression.Call(typeof(Enumerable), "Contains", new[] { me.Type }, ce, me);
            var lambda = Expression.Lambda<Func<T, bool>>(call, pe);
            return query.Where(lambda);
        }
