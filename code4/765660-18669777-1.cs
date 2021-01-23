    protected void gwFacultyStaff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Yes"))     
        {
            GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            Label theLabel = row.FindControl("LabelApproved") as Label;
            theLabel.Text = "TRUE";
        }
        else if (e.CommandName.Equals("No"))
        {
            GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            Label theLabel = row.FindControl("LabelApproved") as Label;
            theLabel.Text = "FALSE";
        }
    }
