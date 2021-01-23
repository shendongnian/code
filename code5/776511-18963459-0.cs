    ....
    
    var encTicket = FormsAuthentication.Encrypt(authTicket);
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
    
    if (authTicket.IsPersistent)
    {
        cookie.Expires = authTicket.Expiration;
    }
    
    Response.Cookies.Add(cookie);
