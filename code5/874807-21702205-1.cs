    protected void Application_Error(object sender, EventArgs e) 
    {  
        Exception exception = Server.GetLastError();
        Response.Clear();
        
        HttpException httpException = exception as HttpException;  
        
        string action = string.Empty;    
        if (httpException != null)
        {
            switch (httpException.GetHttpCode())
            {
                case 404:
                    // page not found 
                    action = "NotFound";
                    break;
                //TODO: handle other codes
                default:
                    action = "general-error";
                    break;
            }
        }
        else
        {
            //TODO: Define action for other exception types
            action = "general-error";
        }
        
        Server.ClearError();
        string culture = Thread.CurrentThread.CurrentCulture.Name;    
        Exception exception = Server.GetLastError();
        Response.Redirect(String.Format("~/{0}/error/{1}", culture, action));
    }
