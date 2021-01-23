    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtAction = (LinkButton) e.Row.FindControl("lbtAction");
            Label lblStatus = (Label) e.Row.FindControl("lblStatus");
            bool active = lblStatus.Text == "Active";
            lbtAction.Text = active ? "Disable" : "Enable";
            string onClientClick  = string.Format("return confirm('Do you want to {0}?')",
                                                   active ? "Disable" : "Enable");
            lbtAction.OnClientClick = onClientClick;
        }
    }
