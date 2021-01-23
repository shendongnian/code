    public static string GetTableAndSchema<T>(this ObjectContext context) where T : class
    {
        var sql = context.CreateObjectSet<T>.ToTraceString();
        var startTrim = sql.LastIndexOf("FROM") + 5;
        var initialTrim = sql.SubString(startTrim);
        var endTrim = initialTrim.IndexOf("AS");
        return sql.Substring(startTrim, endTrim).Replace("[","").Replace("]","");
    }
