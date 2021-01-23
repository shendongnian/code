    protected void Page_Load(object sender, EventArgs e)
    {
    panel1.visible=false;
    panel2.visible=false;
    if(Request.QueryString["Register"]=="pnlCat")
    {
    panel1.visible=true;
    }
    if(Request.QueryString["Register"]=="pnlSubCat")
    {
    panel2.visible=true;
    }
    }
