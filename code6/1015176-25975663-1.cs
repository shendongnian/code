    protected void Session_Start(object source, EventArgs e)
    {
        if (Session.IsNewSession && !externalSystemAvailable)
        {
            Response.Redirect("/Home/Error", false);
            Response.StatusCode = 301;
        } 
    }
