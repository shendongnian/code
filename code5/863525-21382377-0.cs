    static class BooleanComplexifier
    {
        public static Expression<T> Process<T>(Expression<T> expression)
            where T : class
        {
            var body = expression.Body;
            if (body.Type == typeof(bool))
            {
                var unary = body as UnaryExpression;
                if(unary != null && unary.NodeType == ExpressionType.Not)
                {
                    body = Expression.NotEqual(
                        unary.Operand,
                        Expression.Constant(true));
                } else
                {
                    body = Expression.Equal(
                        body,
                        Expression.Constant(true));
                }
                return Expression.Lambda<T>(body, expression.Parameters);
            }
            return expression;
        }   
    }
