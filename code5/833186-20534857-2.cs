    public List<T> GetDataPerPage<T>(int pageNum, int pageSize, Func<T, string> orderBy)
    {
        if (pageSize <= 0) pageSize = 10;  // TODO: Default pageSize for the Moment
        if (pageNum <= 0) pageNum = 1;
        int excludedRows = (pageNum - 1) * pageSize;
        return GetRepo<T>().All(null)
                           .AsQueryable()
                           .Where(p => p.IsDeleted == false)
                           .OrderBy(orderBy)
                           .Skip(excludedRows)
                           .Take(pageSize)
                           .ToList();                                  
    }
