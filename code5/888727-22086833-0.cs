    public virtual HttpResponseMessage UnAuthenticate()
    {
        HttpCookie cookie = HttpContext.Current.Response.Cookies["sessionId"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-1);
        }
        return null;
    }
