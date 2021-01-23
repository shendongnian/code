    private readonly HttpContextBase _httpContext;
    
    public void RedirectToError()
    {
        var httpException = _httpContext.Server.GetLastError();
        if (httpException != null && (_httpContext.Server.GetLastError() is HttpException))
        {
            _httpContext.Server.ClearError();
            // Store the error in the request cache
            _httpContext.Items["LastError"] = httpException;
            _httpContext.Response.Redirect("/Error", false);
        }
    
    }
