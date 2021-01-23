    protected void Page_Init(object sender, EventArgs e)
    {
        CheckSession();
    }
       
    private void CheckSession()
    {
       if (Session["SessionID"] == null || !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
       {
          Response.Redirect("Default.aspx");
       }
    }
