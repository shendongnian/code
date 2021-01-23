    protected void Application_Error()
    {
        //code to log error here, Server.GetLastError()
    	Server.ClearError();
    	Response.StatusCode = 500;
    }
