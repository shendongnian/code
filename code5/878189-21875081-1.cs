    public void Application_Error(object sender, EventArgs e)
    {
         HttpApplication app = (HttpApplication)sender;
         app.Server.Transfer("~/Error.aspx?ErrorID=" + errorId,true);
     }
