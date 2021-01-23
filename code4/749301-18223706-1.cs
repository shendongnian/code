    protected void Page_Load(object sender, EventArgs e)
    {
        bool visible = Request.QueryString["Register"] == "pnlCat";
        Panel1.Visible = visible;
        Panel2.Visible = !visible;
     }
