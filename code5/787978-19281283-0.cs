    public IQueryable<T> Get<T>(Expression<Func<T, bool>> criteria) {
        using (IDbConnection db = dbConnectionFactory.OpenDbConnection())
        {
            return db.Select(criteria).AsQueryable();
        }
    }
