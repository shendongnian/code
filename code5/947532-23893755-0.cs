    protected void LogOutUser(object sender, System.EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect(Request.RawUrl);
    }
