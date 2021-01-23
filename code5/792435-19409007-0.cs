    public IEnumerable<T> PageData<T>(Expression<Func<T, bool>> predicate, 
                                      int pageNumber, 
                                      int pageSize, 
                                      bool trace) 
                                      where T: BaseClassName
    {
        var skip = 0;
        if (pageNumber > 0)
        {
            skip = pageNumber - 1;
        }
        List<T> data;
        using (IDbConnection db = _dbFactory.OpenDbConnection())
        {
            var totalResults = db.Select<T>(predicate);
            data = totalResults.Skip(pageSize * skip).Take(pageSize).ToList();
            if (data.Any())
            {
                var firstRecord = data.FirstOrDefault();
                if (firstRecord != null)
                {
                    int count = totalResults.Count();
                    firstRecord.TotalCount = count
                    firstRecord.TotalPages = count / pageSize;
                    firstRecord.PageNow = pageNumber;
                }
            }
            if (trace) { TraceOut(db.GetLastSql()); }
        }
        return data;
    }
