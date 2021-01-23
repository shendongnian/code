    protected void Transfer_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["page"]="NewApplication.aspx";
            Server.Transfer("~/NewApplicationConfirmation.aspx");
        }
    }
    protected void Edit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Server.Transfer(Session["page"].ToString());
        }
    }
