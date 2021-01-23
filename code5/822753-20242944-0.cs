    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostback)
        {
            loginUserControl.Visible = false;
        }
    }
