    protected void Application_BeginRequest(object source, EventArgs e)
    {
        if (!externalSystemAvailable)
        {
            Response.Redirect("/Home/Error", false);
            Response.StatusCode = 301;
        } 
    }
