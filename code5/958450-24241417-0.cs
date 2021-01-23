    void InternalFrameworkMethodSafe()
    {
        try
        {
            InternalFrameworkMethod();
        }
        catch(InternalFrameworkException e)
        {
            Trace.Write("error in internal method" + e);
        }
    }
    void SomeMethod()
    {
        ...
        InternalFrameworkMethodSafe();
        ...
    }
