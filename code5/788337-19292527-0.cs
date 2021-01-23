    if (reader1.Read())
    {
        role = reader1.GetInt64(0).ToString();
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1,
            tbDomainID.Text,
            DateTime.Now,
            DateTime.Now.AddMinutes(30),
            true,
            role,
            FormsAuthentication.FormsCookiePath);
           
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(
            FormsAuthentication.FormsCookieName,
            hash);
           
        if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
        Response.Cookies.Add(cookie);
