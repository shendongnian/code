    public static Predicate<object> GetPredicate(string column, string valueP, object objSource, string table)
    {
        Type itemType = objSource.GetType();
        ParameterExpression predParam = Expression.Parameter(typeof(object), "p");
        Expression left = Expression.Property(Expression.Convert(predParam, itemType), "A_" + column+ "_" + table);
        var valueStr= Expression.Constant(valueP);
        var typeOfStr = valueStr.Type;
        var containsMethod = typeOfStr.GetMethod("Contains", new [] { typeof(string) });
        var call = Expression.Call(left, containsMethod, valueStr);
        Predicate<object> function = Expression.Lambda<Predicate<object>>(call, new[] { predParam }).Compile();
        return function;
    }
