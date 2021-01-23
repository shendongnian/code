    private static string ConvertExpressionToString(LambdaExpression expr)
    {
        var sb = new StringBuilder();
        var methodCallExpr = expr.Body as MethodCallExpression;
        sb.Append(methodCallExpr.Method.DeclaringType.Name)
            .Append(".")
            .Append(methodCallExpr.Method.Name)
            .Append("(");
        var arguments = methodCallExpr.Arguments;
        for (int i = 0; i < arguments.Count; i++) {
            if (i > 0) {
                sb.Append(", ");
            }
            var constExpr = arguments[i] as ConstantExpression;
            if (constExpr == null) {
                sb.Append("<expr>");
            } else {
                sb.Append(constExpr.ToString());
            }
        }
        sb.Append(");");
        return sb.ToString();
    }
