    var parameter = Expression.Parameter(typeof(Foo));
    var memberExpression = Expression.Property(parameter, "Bar");
    var lambdaExpression = Expression.Lambda(memberExpression, parameter);
    LambdaExpression untyped = lambdaExpression;
    IQueryable<Foo> sorted = Queryable.OrderBy(source, (dynamic)untyped);
    var all = sorted.ToArray();
