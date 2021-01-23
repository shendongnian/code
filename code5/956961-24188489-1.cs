    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "NextGrid")
        {
            LinkButton lb = (LinkButton)e.CommandSource;
            GridViewRow gvr = (GridViewRow)lb.NamingContainer;
            Label lbl = gvr.FindControl("GroupDescription") as Label;
            string description = lbl.Text;
            GridView1.Visible = false;
            GridView2.Visible = true;
            FillDataForGridView2(description) //Fill the Data for GridView2 here and pass description as parameter
        }
    }
