    public IEnumerable<TResult> ListProjected<TResult>(Expression<Func<T, TResult>> selector,
                                            Expression<Func<T, bool>> filter = null,
                                            string include = "",
                                            int Taked = 0)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
            query = query.Where(filter);
        #region Stringleri İnclude Eder
        foreach (var includeProperty in include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        #endregion
        if (Taked != 0)
            query = query.Take(Taked);
        return query.Select(selector).ToList();
    }
