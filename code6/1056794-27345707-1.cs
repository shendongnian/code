    protected void Application_PostAuthorizeRequest() 
    {
        System.Web.HttpContext.Current.SetSessionStateBehavior(
            System.Web.SessionState.SessionStateBehavior.Required);
    }
