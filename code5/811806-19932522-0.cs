    public static class ExpressionExtensions
    {
        public static Expression<Func<T, TProperty>> Lambda<T, TProperty>(this ParameterExpression pe, Expression<Func<T, TProperty>> property)
        {
            return Expression.Lambda<Func<T, TProperty>>(property, pe);
        }
    }
