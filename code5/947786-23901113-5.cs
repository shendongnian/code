    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        { 
            pnlAnonymous.Visible = false;
            pnlVerified.Visible = true;
            litUserName.Text = Context.User.Identity.Name;
        }
        else
        {            
            pnlAnonymous.Visible = true;
            pnlVerified.Visible = false;
        }
     }
