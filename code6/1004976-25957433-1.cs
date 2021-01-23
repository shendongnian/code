    protected void Application_Error()
    {
        var lastException = Server.GetLastError();
        var customException = new Exception("custom message", lastException);
        Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(customException));
    }
