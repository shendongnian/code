    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        { 
            pnlAnonumous.Visible = false;
            pnlVerified.Visible = true;
            litUserName.Text = Context.User.Identity.Name;
        }
        else
        {            
            pnlAnonumous.Visible = true;
            pnlVerified.Visible = false;
        }
     }
