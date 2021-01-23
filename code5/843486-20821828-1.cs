    protected void AccessDataSourceUsers_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        GridViewRow row = GridViewUsers.Rows[GridViewUsers.EditIndex];
        DropDownList ddl = (DropDownList)row.FindControl("DropDownListRoles");
        Label lblUserName = (Label)row.FindControl("lblUserName");
    
        AccessDataSourceUsers.UpdateParameters.Add("@role", ddl.SelectedValue);
        AccessDataSourceUsers.UpdateParameters.Add("@username", lblUserName.Text);
    }
