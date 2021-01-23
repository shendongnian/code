    var query = DataSource.Select(...).Where(...); // as IQueryable<T>
    foreach(string include in includes)
    {
       query = query.Include(include);
    }
    return query.ToList(); // materialize
