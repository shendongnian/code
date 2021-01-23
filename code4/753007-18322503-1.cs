    public static class DynamicQuerier
    {
        private delegate IQueryable<TResult> QueryableMonad<TInput, TResult>(IQueryable<TInput> input, Expression<Func<TInput, TResult>> mapper);
        public static IQueryable<TResult> Select<TInput, TResult>(this IQueryable<TInput> input, string propertyName)
        {
            var property = typeof (TInput).GetProperty(propertyName);
            return CreateSelector<TInput, TResult>(input, property, Queryable.Select);
        }
        private static IQueryable<TResult> CreateSelector<TInput, TResult>(IQueryable<TInput> input, MemberInfo property, QueryableMonad<TInput, TResult> method)
        {
            var source = Expression.Parameter(typeof(TInput), "x");
            Expression propertyAccessor = Expression.MakeMemberAccess(source, property);
            var expression = Expression.Lambda<Func<TInput, TResult>>(propertyAccessor, source);
            return method(input, expression);
        }
    }
