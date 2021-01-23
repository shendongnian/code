    private IQueryable<T> AddIncludes<T>(IDatabase db) // my Entity context class implements IDatabase
    {
        var props = typeof(IDatabase).GetProperties(BindingFlags.Public|BindingFlags.Instance);
        IQueryable<T> ret = null;
        foreach (var prop in props)
        {
            if (prop.PropertyType.Name == "IDbSet`1" &&
            prop.PropertyType.GetGenericArguments()[0] == typeof(T))
            {
                ret = (IQueryable<T>)prop.GetValue(db, null);
                break;
            }
        }
        var includes = GetIncludes((DbContext)db, typeof(T)); // this returns an IEnumerable<string> of the includes
        foreach (var include in includes)
        {
            ret = ret.Include(include);
        }
        return ret;
    }
    
    private ICollection<T> LoadObjectGraph<T>(IDatabase db, Func<T, bool> filter)
    {
    	var queryableWithIncludesAdded = AddIncludes<T>(db);
    	return queryableWithIncludesAdded.Where(filter).ToList();
    } 
