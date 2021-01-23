    protected void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        if (exception is HttpRequestValidationException)
        {
            // use Response.Redirect to get the user back to the page, and use session/querystring to display an error
        }
    }
