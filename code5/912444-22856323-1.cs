    protected void ddlnames_OnChanged(object sender, EventArgs e)
        {
        //Encapsulates the object back as a dropdown list
        DropDownList ddlnames = (DropDownList)sender;
        //Finds the control in the corresponding gridview row and edits the label
        GridViewRow row = (GridViewRow)ddlnames.NamingContainer;
        TextBox IC = (TextBox)row.FindControl("itemCode");
        IC.Text = ddlnames.SelectedValue; 
        }
