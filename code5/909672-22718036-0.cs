    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnAction = (LinkButton) e.Row.FindControl("btnAction");
            Label lblStatus = (Label) e.Row.FindControl("lblStatus");
            btnAction.Text = lblStatus.Text == "Active" ? "Disable" : "Enable";
        }
    }
