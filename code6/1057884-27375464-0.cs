    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        //Get the exception object
        Exception exceptionObject = Server.GetLastError();
        try
        {
            if (exceptionObject != null)
            {
                if (exceptionObject.InnerException != null)
                {
                    exceptionObject = exceptionObject.InnerException;
                }
                switch (exceptionObject.GetType().ToString())
                {
                    case "System.Threading.ThreadAbortException":
                        HttpContext.Current.Server.ClearError();
                        break;
                    default:
                        Elmah.ErrorSignal.FromCurrentContext().Raise(exceptionObject);//Custom method to log error
                        break;
                }
            }
        }
        catch 
        {
            //Avoiding further exception from exception handling
        }
    }
