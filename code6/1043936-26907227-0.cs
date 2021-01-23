    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new LoggingExceptionFilter());
                filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception), View = "Error" }, 1);
                filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(HttpException), View = "HttpExceptionError" }, 2);
              
            }
