    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.User != null && 
            HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MyContext.Current.MyUser = 
               YOURCODE.GetUserByUsername(HttpContext.Current.User.Identity.Name);
        }
    }
