    public ActionResult Reauthenticate(username, password) 
    {
        if (IsValidUser(username, password))
        {  
          // sometimes used to persist user roles
          string userData = string.Join("|",GetCustomUserRoles());
        
          FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1,                                     // ticket version
            username,                              // authenticated username
            DateTime.Now,                          // issueDate
            DateTime.Now.AddMinutes(30),           // expiryDate
            isPersistent,                          // true to persist across browser sessions
            userData,                              // can be used to store additional user data
            FormsAuthentication.FormsCookiePath);  // the path for the cookie
        
          // Encrypt the ticket using the machine key
          string encryptedTicket = FormsAuthentication.Encrypt(ticket);
        
          // Add the cookie to the request to save it
          HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
          cookie.HttpOnly = true; 
          Response.Cookies.Add(cookie);
        }
    }
