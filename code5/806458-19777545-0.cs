    protected void Application_EndRequest()
    {
         if (Context.Response.StatusCode == 302 && Context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            Context.Response.Clear();
            Context.Response.StatusCode = 401;
        }
    }
