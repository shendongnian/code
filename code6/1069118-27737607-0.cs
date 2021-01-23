    static public string GetExpressionText(LambdaExpression p)
    {
        if (p.Body.NodeType == ExpressionType.Convert || p.Body.NodeType == ExpressionType.ConvertChecked)
        {
            p = Expression.Lambda(((UnaryExpression)p.Body).Operand,
                p.Parameters);
        }
        return ExpressionHelper.GetExpressionText(p);
    }
