      if (reader.Read())
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtLogin.Text,
                DateTime.Now, 
                DateTime.Now.AddMinutes(30), 
                true, 
                reader.GetString(0),
                FormsAuthentication.FormsCookiePath);
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
            string returnUrl = Request.QueryString["ReturnUrl"];
            FormsAuthentication.RedirectFromLoginPage("your redirecting page name", false);
    
            if (returnUrl == null)
            {
                returnUrl = "/";
    
            }
        }
