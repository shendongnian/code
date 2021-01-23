    public static MethodResult<T> GetInstance<T>(Func<T> method)
    {
        MethodResult<T> obj = new MethodResult<T>();
        try
        {
            obj.Result = method();
            obj.IsResulted = true;
            obj.Error = null;
        }
        catch (Exception ex)
        {
            obj.Result = default(T);
            obj.IsResulted = false;
            obj.Error = ex;
        }
        return obj;
    }
