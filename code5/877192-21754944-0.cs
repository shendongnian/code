    protected void LoginStatusGiris_LoggedOut(Object sender, System.EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        deleteCookies();
        FormsAuthentication.RedirectToLoginPage();
    }
    private void deleteCookies()
    {
        string[] cookies = Request.Cookies.AllKeys;
        foreach (string cookie in cookies)
        {
            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
        }
    }
