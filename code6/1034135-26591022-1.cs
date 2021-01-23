    public virtual IQueryable<T> Include(this IQueryable<T> qry, params string[] includes)
    {
        foreach(var inc in includes)
             qry = qry.Include(inc);
        return qry;
    }
