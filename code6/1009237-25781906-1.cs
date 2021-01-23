    public static Exception GetInnerMostException(this Exception e)
    {
        if (e == null)
             return null;
        while (e.InnerException != null)
            e = e.InnerException;
        return e;
    }
