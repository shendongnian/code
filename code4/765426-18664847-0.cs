    //left part of lambda, p
    var parameter = Expression.Parameter(typeof(Product), "p");
    //right part
    //p.Attributes
    Expression left = Expression.Property(parameter, "Attributes");
    
    var method = typeof(IDictionary<string, string>).GetMethod("ContainsKey");
    //p.Attributes.ContainsKey("Brand");
    Expression containsExpression = Expression.Call(left, method, Expression.Constant(attribute));
    //p.Attributes["Brand"]
    Expression keyExpression= Expression.Property(left, "Item", new Expression[] { Expression.Constant(attribute) });
    //"Tyco"
    var right = Expression.Constant(value);
    //{p => IIF(p.Attributes.ContainsKey("Brand"), (p.Attributes.Item["Brand"] == "Tyco"), False)}
    Expression operation = Expression.Condition(
                               containsExpression,
                               Expression.MakeBinary(expressionType[op], keyExpression, right), 
                               Expression.Constant(false));
    var lambda = Expression.Lambda<Func<Product, bool>>(operation, parameter);
