    var sourceValue = "AName";
    // You will need the namespace of Bar here!
    var namespaceTargetClassName = "ExpressionProblem";
    var targetClassName = "Bar";
    var targetPropertyName = "AnotherName";
    {
        var targetType = Type.GetType(namespaceTargetClassName + "." + targetClassName);
        var p = Expression.Parameter(targetType, "Target");
        var pr = Expression.PropertyOrField(p, targetPropertyName);
        var e = Expression.Equal(pr, Expression.Constant(sourceValue));
        var lambda = Expression.Lambda(e, p); // It would be an Expression<Func<Bar, bool>>
    }
