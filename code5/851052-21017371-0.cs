    protected void Page_Load(object sender, EventArgs e)
    {
        if (viewdata.CurrentMode == FormViewMode.ReadOnly)
        {
            LoginView lv = (LoginView)viewdata.FindControl("LoginView1");
            Label lblLeft = (Label)lv.FindControl("lblLeft");
        }
    }
