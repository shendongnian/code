    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        if (ddl.SelectedValue == "Approved")
        {
            //Code to approve
        }
        else if (ddl.SelectedValue == "Reject")
        {
            //Code to reject
        }
    }
