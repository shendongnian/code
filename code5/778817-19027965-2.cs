    public static void WriteResponse<T>(ref HttpContext ctx, T sender) 
        where T : class
    {
        var model = sender as T;
        // ...
    }
