    protected void LoginStatusGiris_LoggingOut(object sender, EventArgs e)
        {
    
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            deleteCookies();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
    
    
        }
