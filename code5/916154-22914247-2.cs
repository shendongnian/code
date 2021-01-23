    public static Func<ObjT, bool> PropertyCheck<ObjT, PropT>(string propertyName, Expression<Func<PropT, bool>> predicate)
    {
        var paramExpr = Expression.Parameter(typeof(ObjT));
        var propExpr = Expression.Property(paramExpr, propertyName);
        return Expression.Lambda<Func<ObjT, bool>>(Expression.Invoke(predicate, propExpr), paramExpr).Compile();
    }
