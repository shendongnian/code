    void Application_Error(object sender, EventArgs e)
    {
         Exception ex = Server.GetLastError();
         
         // if there's an Inner Exception we'll most likely be more interested in that
         if (ex .InnerException != null)
         {
             ex = ex .InnerException;
         }
         // filter exception using ex.GetType() ...
         // log exception ...
         // Clear all errors for the current HTTP request.
         HttpContext.Current.ClearError();
    }
