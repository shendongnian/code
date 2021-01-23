    //create ticket
    var ticket = new FormsAuthenticationTicket(
            1, // ticket version
            userName,
            DateTime.Now,
            DateTime.Now.Add(timeout), // timeout
            true, // cookie persistent
            roles,
            FormsAuthentication.FormsCookiePath);
    
    // cookie crypt
    string hash = FormsAuthentication.Encrypt(ticket);
    
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
    cookie.Domain = FormsAuthentication.CookieDomain;
    
    // cookie timeout as ticket timeout
    if (ticket.IsPersistent)
    {
        cookie.Expires = ticket.Expiration;
    }
    CurrentContext.Response.Cookies.Add(cookie);
        ....
    HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
