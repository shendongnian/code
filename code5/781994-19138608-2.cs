    private static IEnumerable<Expression> CollectArguments(MethodCallExpression m) {
        IEnumerable<Expression> args = m.Arguments;
        if (!m.Method.IsStatic)
        {
            var objectExpression = m.Object;
            // Added by me, to deal with interfaces
            if (objectExpression.NodeType == ExpressionType.Constant)
            {
                var objectConstExpression = ((ConstantExpression)objectExpression);
                if (objectConstExpression.Type.IsInterface)
                {
                    objectExpression = Expression.Constant(objectConstExpression.Value);
                }
            }
            args = Enumerable.Repeat(objectExpression, 1).Concat(args);
        }
        return args;
    }
