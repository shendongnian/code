    public static void ReThrow(this Exception ex)
    {
        var exInfo = ExceptionDispatchInfo.Capture(ex); 
        exInfo.Throw();
    }
