    protected void Application_Error(object sender, EventArgs e)
    {
        var error = Server.GetLastError();
        if (!string.IsNullOrWhiteSpace(error.Message))
        {
            //do whatever you want if exception occurs
            Context.ClearError();
        }
    }
