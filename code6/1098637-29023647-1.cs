    Expression<Func<TModel, IEnumerable<TList>>> exp1 = model => model.list;
    Expression<Func<TList, TListValue>> exp2 = listEntry => listEntry.property;
    // get method info of "IEnumerable<>.First()", i.e. "Enumerable.First(this IEnumerable<>)"
    MethodInfo first =
        typeof (System.Linq.Enumerable).GetMethods()
            .Where(m => m.Name == "First" && m.GetParameters().Count() == 1)
            .Single()
            .MakeGenericMethod(new Type[]{typeof(TList)});
    var body = Expression.Property(
        Expression.Call(null, first, exp1.Body), // model.list.First()
        (exp2.Body as MemberExpression).Member as PropertyInfo  // get property info of "TList.property"
        );
    Expression<Func<TModel, TListValue>> result = Expression.Lambda<Func<TModel, TListValue>>(
        body,
        exp1.Parameters
        );
