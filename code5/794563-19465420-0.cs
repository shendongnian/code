    public static IQueryable<T> DataQuery()
    {
        //var args = db.Table1.Select(x => new { x.Code }).Distinct();
        var args = db.Table1.Select(x =>  x.Code ).Distinct();
        return db.Table2.Where(r => args.Contains(r.Code));
    }
