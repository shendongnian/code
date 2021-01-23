    T UnProxy<T>(DbContext context, T proxyObject) where T : class
    {
        var proxyCreationEnabled = context.Configuration.ProxyCreationEnabled;
        try
        {
            context.Configuration.ProxyCreationEnabled = false;
            T poco = context.Entry(proxyObject).CurrentValues.ToObject() as T;
            return poco;
        }
        finally
        {
            context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    }
