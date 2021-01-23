    internal static TType UnwrapProxy<TType>(TType proxy)
    {
        if (!ProxyUtil.IsProxy(proxy))
            return proxy;
    
        try
        {
            dynamic dynamicProxy = proxy;
            return dynamicProxy.__target;
        }
        catch (RuntimeBinderException)
        {
            return proxy;
        }
    }
