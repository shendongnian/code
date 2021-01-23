    static class BooleanComplexifier
    {
        public static Expression<T> Process<T>(Expression<T> expression)
            where T : class
        {
            var body = expression.Body;
            if (body.Type == typeof(bool))
            {
                switch(body.NodeType)
                {
                    case ExpressionType.Equal:
                    case ExpressionType.NotEqual:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.LessThan:
                    case ExpressionType.LessThanOrEqual:
                        return expression;
                    case ExpressionType.Not:
                        body = Expression.NotEqual(
                            ((UnaryExpression)body).Operand,
                            Expression.Constant(true));
                        break;
                    default:
                            body = Expression.Equal(body,
                            Expression.Constant(true));
                        break;
                }
                return Expression.Lambda<T>(body, expression.Parameters);
            }
            return expression;
        }   
    }
