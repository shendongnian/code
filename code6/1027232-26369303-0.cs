        public static IEnumerable<T> Select<T>(this IEnumerable source, string selector, params object[] values)
        {
            return Select(source, selector, values).Cast<T>();
        }
        public static IEnumerable Select(this IEnumerable source, string selector, params object[] values)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.AsQueryable().ElementType, null, selector, values);
            return source.AsQueryable().Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Select",
                    new Type[] { source.AsQueryable().ElementType, lambda.Body.Type },
                    source.AsQueryable().Expression, Expression.Quote(lambda)));
        }
