    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (Request.ContentLength > N) // set the N to the maximum allowed value
        {
            Response.StatusCode = 400;
            Response.End();
        }
    }
