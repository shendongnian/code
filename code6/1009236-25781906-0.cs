    public static Exception GetMostInnerException(this Exception e)
    {
        while (e.InnerException != null)
            e = e.InnerException;
        return e;
    }
