     if (this.ChkRememberme != null && this.ChkRememberme.Checked == true)
     {
        int timeout = rememberMe ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.
        var ticket = new FormsAuthenticationTicket(TxtUserName.Text, TxtPassword.Text);
        string encrypted = FormsAuthentication.Encrypt(ticket);
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
        cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
        cookie.HttpOnly = true; // cookie not available in javascript.
        Response.Cookies.Add(cookie);
    }
