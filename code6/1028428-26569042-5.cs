    public static class QueryableExtensions
    {
        public static Expression<Func<TResult, bool>> WithParameter<TResult, TSource>(this Expression<Func<TSource, bool>> source, Expression<Func<TResult, TSource>> selector)
        {
            // Replace parameter with body of selector
            var replaceParameter = new ParameterVisitor(source.Parameters, selector.Body);
            // This will be the new body of the expression
            var newExpressionBody = replaceParameter.Visit(source.Body);
            return Expression.Lambda<Func<TResult, bool>>(newExpressionBody, selector.Parameters);
        }
    }
