    protected void Page_Load(object sender, System.EventArgs e){ 
        if (Context.User.IsInRole("Admin"))
        {
            uc1:adminlinks.Visible = true;
        }
        else
        {
            uc1:adminlinks.Visible = false;
        }
    }
