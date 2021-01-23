    static Expression<Action<IEnumerable<int>>> BuildExpression()
    {
        ParameterExpression param1 = Expression.Parameter(typeof(IEnumerable<int>), "param1");
        Expression<Func<IEnumerable<int>, int>> firstOrDefault = collection => collection.FirstOrDefault();
        Expression body = Expression.Condition(
            Expression.LessThan(
                Expression.Invoke(firstOrDefault, param1),
                Expression.Constant(10)),
            Expression.Call(
                typeof(Console).GetMethod("WriteLine", new [] { typeof(string) }),
                Expression.Constant("Less")),
            Expression.Call(
                typeof(Console).GetMethod("WriteLine", new [] { typeof(string) }),
                Expression.Constant("Greater or equal"))
            );
        return Expression.Lambda<Action<IEnumerable<int>>>(body, new[] { param1 });
    }
