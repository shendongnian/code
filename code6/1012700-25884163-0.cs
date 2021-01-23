    protected void Application_EndRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.Response.Status.StartsWith("401"))
        {
            HttpContext.Current.Response.ClearContent();
            Response.Redirect("UnauthorizedUsers.aspx");
        }
    }
