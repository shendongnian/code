    public IEnumerable<T> PageData<T>(
        Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, bool trace)
        where T: Baseclass
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
                    firstRecord.TotalCount = totalResults.Count();
                    firstRecord.TotalPages = 
                        (totalResults.Count() + pageSize - 1) / pageSize;
                    firstRecord.PageNow = pageNumber;
                }
            }
            if (trace) { TraceOut(db.GetLastSql()); }
        }
        return data;
    }
