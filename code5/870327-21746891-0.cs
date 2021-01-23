    private static RefCountDisposable _refCountDisposible = new RefCountDisposable();
    private static Session _session = new Session();
    
    public Constructor()
    {
        _refCountDisposible = new RefCountDisposable(
               Disposible.Create(() => _session.Disconnect()));
    }
    public static void Method1() {
        using(_refCountDisposible.GetDisposible())
            if(_session != null)
                _session.Action();
        
    }
    public static void Method2() {
        using(_refCountDisposible.GetDisposible())
        
            if(_session != null)
                _session.Action();
    }
    public static void Method3() {
        using(_refCountDisposible.GetDisposible())
            if(_session != null)
                _session.Action();
    }
    public static void Method4(string path) {
        _refCountDisposible.Dispose()
    }
