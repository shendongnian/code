    public static IBindingNamedWithOrOnSyntax<T> InSessionScope<T>(this IBindingInSyntax<T> parent)
    {
       return parent.InScope(SessionScopeCallback);
    }
    
    private const string _sessionKey = "Ninject Session Scope Sync Root";
    
    private static object SessionScopeCallback(IContext context)
    {
        var cachedItem = AppCache.Cache.Get("MyItem"); // IMPORTANT: For concurrency reason, get the whole item down to method scope.
        if (cachedItem  == null)
        {
            cachedItem = new object();
            AppCache.Cache.Put("MyItem", cachedItem);
        }
        return cachedItem;
    }
