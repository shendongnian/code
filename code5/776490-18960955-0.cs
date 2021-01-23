    public IQueriable<T> YourMethodName<T, TKey>(Expression<Fun<T,TKey>> keyselector)
    {
        DbQuery<T> query = Context.Set<T>();
        
         query = IncludeNavigationProperties(query, includedProperties);
        
         var result =  query.OrderBy(keySelector)
                            .Skip((pageNumber - 1)*pageSize)
                            .Take(pageSize).ToList();
    }
