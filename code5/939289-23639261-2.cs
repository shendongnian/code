    public static void HandleError(ServiceAServiceReference.ExceptionResponseMessage ex)
    {
        HandleErrorDynamic(ex);
    }
    
    public static void HandleError(ServiceBServiceReference.ExceptionResponseMessage ex)
    {
        HandleErrorDynamic(ex);
    }
    private static void HandleErrorDynamic(dynamic ex)
    {
        //(Method Implementation here)
    }    
