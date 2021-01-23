    void Application_Error(..)
    {
       var ex = Server.GetLastError();
       if (ex != null && ex is <whateverexceptiontype>) { // or check ex.Message matches
         HttpContext.Current.Response.Redirect("niceerrorpage.aspx")
       }
    }
