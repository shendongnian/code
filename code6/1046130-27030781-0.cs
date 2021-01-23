    private void AddOrSetCookie(HttpCookie cookie, String cookieName)
    {
        if (System.Web.HttpContext.Current.Request.Cookies[cookieName] == null
            || System.Web.HttpContext.Current.Request.Cookies[cookieName].Value != cookie.Value )
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }
       
    }
