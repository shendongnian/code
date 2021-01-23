        public object Execute(Expression expression)
        {
            var query1 = ChangeQuerySource(expression, Expression.Constant(source1));
            var query2 = ChangeQuerySource(expression, Expression.Constant(source2));
            dynamic results1 = source1.Provider.Execute(query1);
            dynamic results2 = source2.Provider.Execute(query2);
            return Enumerable.Concat(results1, results2);
        }
        private static Expression ChangeQuerySource(Expression query, Expression newSource)
        {
            // step 1: cast the Expression as a MethodCallExpression.
            // This will usually work, since a chain of LINQ statements
            // is generally a chain of method calls, but I would not
            // make such a blind assumption in production code.
            var methodCallExpression = (MethodCallExpression)query;
            // step 2: Create a new MethodCallExpression, passing in
            // the existing one's MethodInfo so we're calling the same
            // method, but just changing the parameters. Remember LINQ
            // methods are extension methods, so the first argument is
            // always the source. We carry over any additional arguments.
            query = Expression.Call(
                methodCallExpression.Method,
                new Expression[] { newSource }.Concat(methodCallExpression.Arguments.Skip(1)));
            // step 3: We call .AsEnumerable() at the end, to get an
            // ultimate return type of IEnumerable<T> instead of
            // IQueryable<T>, so we can safely use this new expression
            // tree in any IEnumerable statement.
            query = Expression.Call(
                typeof(Enumerable).GetMethod("AsEnumerable", BindingFlags.Static | BindingFlags.Public)
                .MakeGenericMethod(
                    TypeSystem.GetElementType(methodCallExpression.Arguments[0].Type)
                ),
                query);
            return query;
        }
