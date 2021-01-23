    var result = new List<A>();
    var anonymous = new { t1 = (A)null, t2 = (B)null };
    var condition = GetPropertyCondition(anonymous, prop);
    using (var db = new DataContext())
    {
        result = db.Table1.AsQueryable()
                   .Join(db.Table2.AsQueryable(), t1 => t1.Id, t2 => t2.Id, (t1, t2) => new { t1, t2 })
                   .Where(condition)
                   .Select(t => t.t1)
                   .ToList();
    }
    return result;
