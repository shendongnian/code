    protected void Application_Error(Object sender, EventArgs e)
    {
        HttpContext ctx = HttpContext.Current;
        Exception exception = ctx.Server.GetLastError();
        int httpCode = ((HttpException)exception).GetHttpCode(); // check if it is 500
    }
