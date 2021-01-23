    static T GetNestedException<T>(Exception ex) where T : Exception
    {
        if (ex == null) { return null; }
        var tEx = ex as T;
        if (tEx != null) { return tEx; }
        return GetNestedException<T>(ex.InnerException);
    }
