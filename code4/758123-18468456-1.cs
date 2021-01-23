    public static Predicate<object> GetPredicate(string column, string valueP, object objSource, string table)
    {
        Type itemType = objSource.GetType();
        ParameterExpression predParam = Expression.Parameter(typeof(object), "p");
        Expression left = Expression.Property(Expression.Convert(predParam, itemType), "A_" + column+ "_" + table);
        var valueStr= Expression.Constant(valueP);
        var typeOfStr = valueStr.Type;
        var containsMethod = typeOfStr.GetMethod("Contains", new [] { typeof(string) });
        var call = Expression.Call(left, containsMethod, valueStr);
        //To handle null values. It considers null == string.Empty
        //var left2 = Expression.Coalesce(left, Expression.Constant(string.Empty));
        //var call = Expression.Call(left2, containsMethod, valueStr);
        //If you want null values to be distinct from string.Empty, it's
        //much more complex. You'll need a temporary variable (left2)
        //where to put the value of the property, and then you can use the 
        //Expression.Condition (that is the ? : ternary operator) to 
        //test for null values
        //var left2 = Expression.Variable(typeof(string));
        //var assign = Expression.Assign(left2, left);
        //var notNull = Expression.NotEqual(left2, Expression.Constant(null));
        //var call = Expression.Call(left2, containsMethod, valueStr);
        //var condition = Expression.Condition(notNull, call, Expression.Constant(false));
        //var block = Expression.Block(new[] { left2 }, new Expression[] { assign, condition });
        Predicate<object> function = Expression.Lambda<Predicate<object>>(call, new[] { predParam }).Compile();
        return function;
    }
