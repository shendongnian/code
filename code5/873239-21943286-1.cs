    public static Aggregation Aggregate(this IQueryable source, string member)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (member == null)
            throw new ArgumentNullException("member");
        // Properties
        PropertyInfo property = source.ElementType.GetProperty(member);
        ParameterExpression parameter = Expression.Parameter(source.ElementType, "s");
        Expression selector = Expression.Lambda(Expression.MakeMemberAccess(parameter, property), parameter);
        // We've tried to find an expression of the type Expression<Func<TSource, TAcc>>,
        // which is expressed as ( (TSource s) => s.Price );
        // Methods
        MethodInfo sumMethod = typeof(Queryable).GetMethods().First(
            m => m.Name == "Sum"
                && m.ReturnType == property.PropertyType // should match the type of the property
                && m.IsGenericMethod);
        MethodInfo averageMethod = typeof(Queryable).GetMethods().First(
            m => m.Name == "Average"
                && m.IsGenericMethod
                && m.GetParameters()[1]
                    .ParameterType
                        .GetGenericArguments()[0]
                            .GetGenericArguments()[1] == property.PropertyType);
        MethodInfo countMethod = typeof(Queryable).GetMethods().First(
            m => m.Name == "Count"
                && m.IsGenericMethod);
        return new Aggregation(
            source.Provider.Execute(
                Expression.Call(
                    null,
                    sumMethod.MakeGenericMethod(new[] { source.ElementType }),
                    new[] { source.Expression, Expression.Quote(selector) })),
            source.Provider.Execute(
                Expression.Call(
                    null,
                    averageMethod.MakeGenericMethod(new[] { source.ElementType }),
                    new[] { source.Expression, Expression.Quote(selector) })),
            (int)source.Provider.Execute(
                Expression.Call(
                    null,
                    countMethod.MakeGenericMethod(new[] { source.ElementType }),
                    new[] { source.Expression })));
    }
