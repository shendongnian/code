    public static Object ResolveTest(Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == _lazyType)
        {
            var arg = type.GetGenericArguments()[0];
            Expression<Func<object>> expressionWithFuncOfTypeObject = () => ResolveType(arg);
            UnaryExpression expressionThatEvaluatesToAnObjectOfTypeArg = Expression.Convert(expressionWithFuncOfTypeObject.Body, arg);
            LambdaExpression expressionWithFuncOfTypeArg = Expression.Lambda(typeof(Func<>).MakeGenericType(arg), expressionThatEvaluatesToAnObjectOfTypeArg);
            Delegate funcOfTypeArg = expressionWithFuncOfTypeArg.Compile(); // <-- At runtime this will be of type Func<T>
            return Activator.CreateInstance(_lazyType.MakeGenericType(arg), funcOfTypeArg);
        }
        else
            return ResolveType(type);
    }
