    case ExpressionType.MemberAccess:
        var memberExpression = (MemberExpression) expression;
        if (memberExpression.Expression.NodeType == ExpressionType.Parameter ||
            memberExpression.Expression.NodeType == ExpressionType.Convert)
            return memberExpression.Member;
        throw new Exception();
