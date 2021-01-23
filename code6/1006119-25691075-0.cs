    public static string GetViewSql<T>(this DbContext db, IQueryable<T> q)
        where T : class
    {
        const string prefix = "view_";
        var tableName = Regex.Match(
            db.Set<T>().ToString(), 
            @"FROM (\[.*\]\.\[.*\]) AS \[Extent1\]").Groups[1].Value;
        var viewName = Regex.Replace(
            tableName, 
            @"\[.*\]\.\[(.*)\]", 
            m => m.Groups[0].Value.Replace(
                m.Groups[1].Value, prefix + m.Groups[1].Value));
        var sql = q.ToString().Replace(tableName, viewName);
        return sql;
    }
