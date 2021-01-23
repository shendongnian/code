    LambdaExpression idExpr = list[0];
    Type keyType = idExpr.ReturnType;
    
    var orderByMethod = typeof(Queryable).GetMethods()
        .Single(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
        .MakeGenericMethod(typeof(Entity), keyType);
    
    var ordered = (IQueryable<Entity>)orderByMethod.Invoke(null, new object[] { source, idExpr });
