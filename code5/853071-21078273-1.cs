    List<T> result;
    var param = Expression.Parameter(typeof(B), "x");
    var trueExp = Expression.Constant(true);
    var condition = Expression.Equal(Expression.Property(param, prop), trueExp);
    var whereLambda = Expression.Lambda<Func<B, bool>>(condition, param);
    using (var db = new DataContext())
    {
        result = db.Table1
                   .Join(db.Table2.Where(whereLambda),
                         t1 => t1.Id,
                         t2 => t2.Id,
                         (t1, t2) => new { t1, t2 })
                   .Select(t => t.t1)
                   .ToList();
    }
    return result;
