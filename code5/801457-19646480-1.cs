    public static Expression<Func<TInput, TOutput>>
        ModifyInputSelectorToOperatorOnAnonymousType
        <TInput, TOutput, TParam1, TParam2, TParam3>(
        //this first param won't be used; 
        //it's here to allow type inference
        IQueryable<TInput> exampleParam,
        Expression<Func<TInput, TParam1>> firstSelector,
        Expression<Func<TInput, TParam2>> secondSelector,
        Expression<Func<TInput, TParam3>> thirdSelector,
        Expression<Func<TParam1, TParam2, TParam3, TOutput>> finalSelector)
    {
        var parameter = Expression.Parameter(typeof(TInput), "param");
        var first = firstSelector.Body.Replace(firstSelector.Parameters.First(),
            parameter);
        var second = secondSelector.Body.Replace(secondSelector.Parameters.First(),
            parameter);
        var third = thirdSelector.Body.Replace(thirdSelector.Parameters.First(),
            parameter);
        var body = finalSelector.Body.Replace(finalSelector.Parameters[0], first)
            .Replace(finalSelector.Parameters[1], second)
            .Replace(finalSelector.Parameters[2], third);
        return Expression.Lambda<Func<TInput, TOutput>>(body, parameter);
    }
