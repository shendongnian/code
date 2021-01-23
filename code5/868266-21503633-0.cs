    public static string MaxDepartment<U>(IQueryable<U> table)
    {
        var parameter = Expression.Parameter(typeof(U));
        var property = Expression.Property(parameter, "LastUpdated");
        var lambada = Expression.Lambda<Func<U, byte[]>>(property, parameter);
        var results = table.Max(lambada);
        string hex = BitConverter.ToString(results);
        hex = hex.Replace("-", "");
        return hex;
    }
