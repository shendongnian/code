    private TResult ExecuteWithExceptionHandling<TParam, TResult>(TParam parameter, Func<TParam, TResult> func)
    {
        try
        {
            return func(parameter);
        }
        catch (Exception e)
        {
            this.Logger(e);
        }
        return default(TResult);
    }
    public Object1 Method1(Object2 parameter)
    {
        return ExecuteWithExceptionHandling(parameter, linkToMyServer.Method1);
    }
    public Object3 Method2(Object4 parameter)
    {
        return ExecuteWithExceptionHandling(parameter, linkToMyServer.Method2);
    }
