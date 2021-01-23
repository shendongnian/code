    public Expression GetParameterByName(PropertyInfo pi)
    {
        var fieldName = Expression.Parameter(typeof(RuleViewModel<T>), "x");
        var fieldExpression = Expression.PropertyOrField(
            Expression.Property(fieldName, "RuleModel"),
            pi.Name);
        var exp = Expression.Lambda(
            typeof(Func<,>).MakeGenericType(typeof(RuleViewModel<T>), fieldExpression.Type),
            fieldExpression,
            fieldName);
        return exp;
    }
    // ...
    @InputExtensions.TextBoxFor(Html, (dynamic)Model.GetParameterByName(prop))
