     FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, 
         txtUsername.Text, 
         DateTime.Now, DateTime.Now.AddMinutes(1), 
         true, 
         role, 
         FormsAuthentication.FormsCookiePath);
     HttpCookie cookie = new HttpCookie(
         FormsAuthentication.FormsCookieName, 
         FormsAuthentication.Encrypt(ticket));
     if (ticket.IsPersistent) 
         cookie.Expires = ticket.Expiration;
     Response.Cookies.Add(cookie);
    
    /* Delete this line
     FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);  */
