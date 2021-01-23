    public static MethodInfo GetMethodInfo(Expression<Action> expression)
    {
        var member = expression.Body as MethodCallExpression;
    
        if (member != null)
            return member.Method;
    
        throw new ArgumentException("Expression is not a method", "expression");
    }
