    protected void Application_EndRequest()
    {
        if (HttpContext.Current.Items["remove-auth-cookie"] != null)
        {
            Context.Response.Cookies.Remove(System.Web.Security.FormsAuthentication.FormsCookieName);
        }
    }
