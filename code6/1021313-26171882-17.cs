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
            // This is a tricky case because of the "object" return type.
            // An expression which targets a value type property will
            // have a UnaryExpression body, whereas an expression which
            // targets a reference type property will have a MemberExpression
            // (or, more specifically, PropertyExpression) Body.
            var unaryExpr = expr.Body as UnaryExpression;
            var memberExpr = (MemberExpression)(unaryExpr == null ? expr.Body : unaryExpr.Operand);
            return memberExpr.Member;
        }
    }
