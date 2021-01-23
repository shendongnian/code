    void Application_Error(object sender, EventArgs e)
    {
         Exception ex = Server.GetLastError();
         // process exception
         // redirect
         HttpContext.Current.ClearError();             
         Response.Redirect("~/Error.aspx", false);
         return;
    }
