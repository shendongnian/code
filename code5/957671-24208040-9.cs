    static bool IsDateTime(Type type) {
        return GetNonNullableType(type) == typeof(DateTime);
    }
    static bool IsStringLiteral(Expression e) {
        var c = e as ConstantExpression;
        return c != null && c.Value is string;
    }
