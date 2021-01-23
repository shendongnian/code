    public static class ExpressionUtil
    {
        public static PropertyInfo Property<T>(Expression<Func<T, object>> expr)
        {
            var member = ExpressionUtil.Member(expr);
            var prop = member as PropertyInfo;
            if (prop == null)
            {
                throw new InvalidOperationException("Specified member is not a property.");
            }
            return prop;
        }
        public static MemberInfo Member<T>(Expression<Func<T, object>> expr)
        {
            var unaryExpr = (UnaryExpression)expr.Body;
            var memberExpr = (MemberExpression)unaryExpr.Operand;
            return memberExpr.Member;
        }
    }
...
    // includeProperties is Expression<Func<TModel, object>>[].
    var propertyInfos = includeProperties
        .Select(ExpressionUtil.Property)
        .ToList();
