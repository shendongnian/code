    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        /// Code to get user
        ...
        ContextHelper.GetHttpContextBase().User = user;
    }
