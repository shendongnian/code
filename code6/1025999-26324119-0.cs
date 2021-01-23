    var parameter = Expression.Parameter(typeof (IEnumerable<GrouppedStockGift>));
    var sumMethodint = typeof(Enumerable).GetMethods()
                .Single(x => x.Name == "Sum"
                            && x.GetParameters().Count() == 2
                            && x.GetParameters()[1]
                                .ParameterType
                                .GetGenericArguments()[1] == typeof(int));
    sumMethodint = sumMethodint.MakeGenericMethod(typeof(GrouppedStockGift));
    Expression<Func<GrouppedStockGift, int>> saleCount = y => y.SaleCount;
    var saleCountExtractor = Expression.Call(sumMethodint, parameter, saleCount);
    
    bindings.Add(Expression.Bind(typeof(GrouppedStockGift).GetProperty("SaleCount"),
                                 saleCountExtractor));
