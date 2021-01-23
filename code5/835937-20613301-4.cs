     protected void Application_Error(Object sender, EventArgs e)
        {
            HttpException serverError = Server.GetLastError() as HttpException;
    
            if (null != serverError)
            {
                int errorCode = serverError.GetHttpCode();
    
                if (404 == errorCode)
                {
                    Server.ClearError();
                    Server.Transfer("Your virtual path");
    
                }
            }
        }
