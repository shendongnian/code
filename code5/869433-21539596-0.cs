    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddDays(1), false, model.Email);
    
    string hashedTicket = FormsAuthentication.Encrypt(ticket);
    
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket);
    
    HttpContext.Response.Cookies.Add(cookie);
