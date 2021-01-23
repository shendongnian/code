    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsSecureConnection.Equals(true) && HttpContext.Current.Request.IsLocal.Equals(true))
        {
           Response.Redirect("http://" + Request.ServerVariables["HTTP_HOST"]
           + HttpContext.Current.Request.RawUrl);
        }
    }
