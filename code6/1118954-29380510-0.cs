    string roles = "Admin,Member";
    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
        1,
        userId,  //user id
        DateTime.Now,
        DateTime.Now.AddMinutes(20),  // expiry
        false,  //do not remember
        roles, 
        "/");
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                       FormsAuthentication.Encrypt(authTicket));
    Response.Cookies.Add(cookie);
