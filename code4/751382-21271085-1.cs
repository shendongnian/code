    protected void Application_Error()
    {
    	var error = Server.GetLastError();
    	Server.ClearError();
    	//code to log error here
    	var httpException = error as HttpException;
    	Response.StatusCode = httpException != null ? httpException.GetHttpCode() : (int)HttpStatusCode.InternalServerError;
    }
