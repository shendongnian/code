     protected void Application_OnError( )
        {
            var exception = Server.GetLastError( );
    
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
    
            Helper.SetSessionValue(SessionKeys.EXCEPTION, exception);
    
            Response.Redirect( "~/Error/ShowException");
        }
