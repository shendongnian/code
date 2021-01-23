    if (bypassSlidingExpiration)
    {
        var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        authCookie.Expires = DateTime.MaxValue;
        Response.Cookies.Add(authCookie);
    }
