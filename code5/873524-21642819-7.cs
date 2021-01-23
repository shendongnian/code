    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        System.Web.Security.FormsAuthentication.RedirectToLoginPage();
    }
