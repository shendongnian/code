    protected void AccessDataSource_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
      // Moved code to the method below
    }
    
    protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridViewUsers.Rows[GridViewUsers.EditIndex];
        var ddl = row.FindControl("DropDownListRoles") as DropDownList;
        var lblUserName = row.FindControl("lblUserName") as Label;
        if (ddl != null && ddl.SelectedValue != null && lblUserName != null)
        {
            AccessDataSourceUsers.UpdateParameters.Add("@role", ddl.SelectedValue);
            AccessDataSourceUsers.UpdateParameters.Add("@username", lblUserName.Text);
            AccessDataSourceUsers.Update();
        }
    }
