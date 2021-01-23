    public static object GetFlattenPropertyValue(this object source, string flattenPropertyName) {
        var expression = source.GetType().CreatePropertyExpression(flattenPropertyName);
        if (expression != null) {
            var getter = expression.Compile();
            return getter.DynamicInvoke(source);
        }
        return null;
    }
    public static LambdaExpression CreatePropertyExpression(this Type type, string flattenPropertyName) {
        if (flattenPropertyName == null) {
            return null;
        }
        var param = Expression.Parameter(type, "x");
        Expression body = param;
        foreach (var member in flattenPropertyName.Split('.')) {
            body = Expression.PropertyOrField(body, member);
        }
        return Expression.Lambda(body, param);
    }
