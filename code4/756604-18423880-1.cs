    source.Provider.CreateQuery(
        Expression.Call(
            typeof(Queryable),
            "Select",
            new Type[] { source.ElementType, lambda.Body.Type },
            source.Expression,
            Expression.Quote(lambda)));
