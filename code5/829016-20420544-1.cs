    public IEnumerable<T> GetData<T>(Expression<Func<IEnumerable<T>>> callbackExpression) 
    where T : class    
    {
        var methodCall = callbackExpression.Body as MethodCallExpression;
        if(methodCall != null)
        {
            string methodName = methodCall.Method.Name;
        }
    
        return callbackExpression.Compile()();
    }
