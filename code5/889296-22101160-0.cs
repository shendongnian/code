    if (bypassSlidingExpiration)
    {
        var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        authCookie.Expires = DateTime.MaxValue;
        Request.Cookies.Add(authCookie);
    }
