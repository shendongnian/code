    public void RequestData<TResult>()
    {
        Type type = typeof(TResult);
        string myName;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            myName = type.GetGenericArguments()[0].Name;
        }
        else
        {
            myName = typeof(TResult).Name;
        }
    }
