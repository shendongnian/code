    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        var error = new HandleErrorAttribute();
        error.ExceptionType = typeof (ArgumentException);
        error.View = "MissingArgument";
        filters.Add(error);
    }
