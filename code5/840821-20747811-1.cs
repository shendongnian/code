    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (ValidateUser(UserNameTextBox.Value, PasswordTextBox.Value))
             {
                     // get the department from your DB
                     string department = DB.GetDepartmentByUsername(UserNameTextBox.Value);
                     FormsAuthenticationTicket tkt;
                     string cookiestr;
                     HttpCookie ck;
                              tkt = new FormsAuthenticationTicket(2,  // version 
                              UserNameTextBox.Value, 
                              DateTime.Now, 
                              DateTime.Now.AddMinutes(30), 
                              RemPassword.Checked, 
                              department, // instead of custom data
                              FormsAuthentication.FormsCookiePath);
                     cookiestr = FormsAuthentication.Encrypt(tkt);
                     ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                     if (RemPassword.Checked)
                     ck.Expires = tkt.Expiration;
                     ck.Path = FormsAuthentication.FormsCookiePath;
                     Response.Cookies.Add(ck);
    
                     string strRedirect;
                     strRedirect = Request["ReturnUrl"];
                     if (strRedirect == null)
                     strRedirect = "Home.aspx";
                     Response.Redirect(strRedirect, true);
             }
                     else
                     Response.Redirect("Login.aspx", true);
    }
