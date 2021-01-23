    ...
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    HttpOnly = true,
                    Secure = FormsAuthentication.RequireSSL,
                    Path = FormsAuthentication.FormsCookiePath
                };
    if (authTicket.IsPersistent)
    {
       cookie.Expires = encTicket.Expiration;
    }
    if (FormsAuthentication.CookieDomain != null)
    {
       cookie.Domain = FormsAuthentication.CookieDomain;
    }
    Response.Cookies.Add(cookie);
