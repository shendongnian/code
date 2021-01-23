    DbSet = Context.Set<T>();
    public IQueryable<T> GetAll(int pageNumber = 0, int pageSize = 10, string sortColumn = "")
    {
        return DbSet.OrderBy(GetKeyField(typeof(T))).Skip(pageNumber * pageSize)Take(pageSize);
    }
