    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute
      {
        ExceptionType = typeof(System.TimeoutException),
        View = "TimeoutExceptionView"
      });
     
      filters.Add(new HandleErrorAttribute()); //by default added
    }
