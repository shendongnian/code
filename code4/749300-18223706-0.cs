    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Register"] == "pnlCat")
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else if (Request.QueryString["Register"] == "pnlSubCat")
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }
