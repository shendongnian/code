     protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack)
                    return;
    
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
