    // This could be a parameter
    var data = Expression.Constant(products);
    var outterGroupByarg = Expression.Parameter(typeof(Product), "x");
    var outterGroupNameProperty = Expression.PropertyOrField(outterGroupByarg, "Category");
    var outterGroupByLambda = Expression.Lambda<Func<Product, string>>(outterGroupNameProperty, outterGroupByarg);
    var outterGroupByExpression = Expression.Call(typeof(Enumerable), "GroupBy", new [] { typeof(Product), typeof(string) },
                                             data, outterGroupByLambda);
    var outterSelectParam = Expression.Parameter(typeof (IGrouping<string, Product>), "p");
    var innerGroupByarg = Expression.Parameter(typeof(Product), "y");
    var innerGroupNameProperty = Expression.PropertyOrField(innerGroupByarg, "Subcategory");
    var innerGroupByLambda = Expression.Lambda<Func<Product, string>>(innerGroupNameProperty, innerGroupByarg);
    var innerGroupByExpression = Expression.Call(typeof(Enumerable), "GroupBy", new[] { typeof(Product), typeof(string) },
                                             outterSelectParam, innerGroupByLambda);
    var innerAnonymousType = new {Key = "abc", objects = new List<Product>()};
    var innerSelectProjectionarg = Expression.Parameter(typeof(IGrouping<string, Product>), "y");
    var innerKeyProp = Expression.Property(innerSelectProjectionarg, "Key");
    
    var innerToList = Expression.Call(typeof (Enumerable), "ToList", new[] {typeof (Product)},
                                      innerSelectProjectionarg);
    var innerAnonymousResultType = innerAnonymousType.GetType();
    var innerAnonymousConstructor =
        innerAnonymousResultType.GetConstructor(new[] {typeof (string), typeof (List<Product>)});
    var innerAnonymous = Expression.New(innerAnonymousConstructor, innerKeyProp, innerToList);
    var innerSelectProjection =
        Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(IGrouping<string, Product>), innerAnonymousResultType), innerAnonymous,
                          innerSelectProjectionarg);
    var innerSelectExpression = Expression.Call(typeof(Enumerable), "Select", new [] { typeof(IGrouping<string, Product>), innerAnonymousResultType },
                                innerGroupByExpression, innerSelectProjection);
    var outterAnonymousType = new {Key = "abc", Values = new[] {innerAnonymousType}.AsEnumerable()};
    var outterAnonymousResultType = outterAnonymousType.GetType();
    var outterAnonymousConstructor =
        outterAnonymousResultType.GetConstructor(new[] { typeof(string), typeof(IEnumerable<>).MakeGenericType(innerAnonymousResultType) });
    var outterKeyProp = Expression.PropertyOrField(outterSelectParam, "Key");
    var outterAnonymous = Expression.New(outterAnonymousConstructor, outterKeyProp, innerSelectExpression);
    var outterSelectProjection =
        Expression.Lambda(
            typeof (Func<,>).MakeGenericType(typeof (IGrouping<string, Product>), outterAnonymousResultType),
            outterAnonymous,
            outterSelectParam);
    var outterSelect = Expression.Call(typeof(Enumerable), "Select", new[] { typeof(IGrouping<string, Product>), outterAnonymousResultType },
                                      outterGroupByExpression, outterSelectProjection);
    
    // Lamda is a func with no input because list of products was set as a constant and not a parameter
    var finial =
        Expression.Lambda(
            typeof (Func<>).MakeGenericType(typeof (IEnumerable<>).MakeGenericType(outterAnonymousResultType)),
            outterSelect);
