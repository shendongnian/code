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
            var methodCallExpression = (MethodCallExpression)query;
            query = Expression.Call(
                methodCallExpression.Method,
                new Expression[] { newSource }.Concat(methodCallExpression.Arguments.Skip(1)));
            query = Expression.Call(
                typeof(Enumerable).GetMethod("AsEnumerable", BindingFlags.Static | BindingFlags.Public)
                .MakeGenericMethod(
                    TypeSystem.GetElementType(methodCallExpression.Arguments[0].Type)
                ),
                query);
            return query;
        }
