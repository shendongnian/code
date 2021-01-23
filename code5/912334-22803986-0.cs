    protected void Page_Init(object sender, EventArgs e)
    {
    CheckSession();
    }
       
    private void CheckSession()
    {
    if (Session["SessionID"] == null)
    {
    Response.Redirect("Default.aspx");
    }
    
    }
