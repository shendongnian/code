    string methodAsc = "OrderBy";
    string methodDesc = "OrderByDescending";
    var mce = q.Expression;
    foreach (var fieldName in fieldsToSort)
    {
        var method = fieldName.Value ? methodAsc : methodDesc;
        var prop = Expression.Property(param, fieldName.Key);
        var exp = Expression.Lambda(prop, param);
        var types = new Type[] { q.ElementType, exp.Body.Type };
        mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
        methodAsc = "ThenBy";
        methodDesc = "ThenByDescending";
    }
    return q.Provider.CreateQuery<T>(mce);
