    protected void Page_Init(object sender, EventArgs e)
    {
        //If this page is not AccessDenied.aspx
        if(Request.Path != "~/Pages/Error/AccessDenied.aspx")
        {
            MenuAccess();
        }
    }
