    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row
            DropDownList ddlRole = (e.Row.FindControl("ddlRole") as DropDownList);
            ddlRole.DataSource = GetData("SELECT RoleType FROM TableName");
            ddlRole.DataTextField = "RoleType";
            ddlRole.DataValueField = "RoleType";
            ddlRole.DataBind();
            //Add Default Item in the DropDownList
            ddlRole.Items.Insert(0, new ListItem("Please select"));
            //Select the role of user in DropDownList
            string role = (e.Row.FindControl("lblRole") as Label).Text;
            ddlRole.Items.FindByValue(role).Selected = true;
        }       
    }
