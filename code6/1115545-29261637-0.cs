    protected void Transfer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Server.Transfer("~/NewApplicationConfirmation.aspx?page=NewApplication");
            }
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Server.Transfer(Request.QueryString["page"] + ".aspx");
            }
        }
