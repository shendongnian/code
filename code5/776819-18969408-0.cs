    public IEnumerable<T> f1(IEnumerable<T> query)
    {
      if (query is IQueryable<T>)
      {
        return query.Take(10).ToList();
      }
      return null;
    }
    public IEnumerable<T> f2(IEnumerable<T> query)
    {
      if (query is IQueryable<T>)
      {
        return query.Where(id => (id % 100000000) == 0).ToList();
      }
      return null;
    }
