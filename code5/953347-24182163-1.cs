    protected void Application_Error(object sender, EventArgs e)
    {
        Exception exception = Server.GetLastError();
        System.Diagnostics.Debug.WriteLine(exception);
        if (exc.GetType() == typeof(TimeoutException)
        {
          Response.Redirect("/Home/ErrorView");
        }
    }
