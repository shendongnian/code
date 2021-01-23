    protected void cmdLogin_ServerClick(object sender, System.EventArgs e)
    {
        if (String.Equals(txtUserName.Value, "johndoe", 
            StringComparison.InvariantCultureIgnoreCase) &&
            String.Equals(txtUserPass.Value, "123456", 
            StringComparison.InvariantCultureIgnoreCase))
        {
            var roles = new[] {"Administrators"};
            var ticket = new FormsAuthenticationTicket(1, 
                txtUserName.Value,
                DateTime.Now,
                DateTime.Now.AddMinutes(30), 
                chkPersistCookie.Checked,
                string.Join(",", roles),
                FormsAuthentication.FormsCookiePath);
    
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
                FormsAuthentication.Encrypt(ticket));
    
            if (chkPersistCookie.Checked)
                cookie.Expires = ticket.Expiration;
    
            Response.Cookies.Add(cookie);
    
            string returnUrl = Request["ReturnUrl"];
            if (returnUrl == null)
                returnUrl = "default.aspx";
            Response.Redirect(returnUrl, true);
        }
        else
            Response.Redirect("1.0.0.0_LoginScreen.aspx", true);
    }
