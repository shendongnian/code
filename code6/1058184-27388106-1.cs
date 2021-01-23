    /// <summary>
    /// Create an Action&lt;T> delegate instance which will call the
    /// given method, using the given instance, casting the argument
    /// of type T to the actual argument type of the method.
    /// </summary>
    /// <typeparam name="T">The type for the delegate's parameter</typeparam>
    /// <param name="b">The instance of the object for the method call</param>
    /// <param name="miCommand">The method to call</param>
    /// <returns>A new Action&lt;T></returns>
    private static Action<T> CreateAction<T>(B b, MethodInfo miCommand)
    {
        // Create the parameter object for the expression, and get
        // the type needed for it
        ParameterExpression tParam = Expression.Parameter(typeof(T));
        Type parameterType = miCommand.GetParameters()[0].ParameterType;
        // Create an expression to cast the parameter to the correct type
        // for the call
        Expression castToType = Expression.Convert(tParam, parameterType, null);
        // Create the delegate itself: compile a lambda expression where
        // the lambda calls the method miCommand using the instance b and
        // passing the result of the cast expression as the argument.
        return (Action<T>)Expression.Lambda(
                Expression.Call(
                    Expression.Constant(b, b.GetType()),
                    miCommand, castToType),
                tbParam).Compile();
    }
