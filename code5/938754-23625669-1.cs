     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
       if (e.Row.RowType == DataControlRowType.DataRow)
         {
           //Find the DropDownList in the Row
          DropDownList ddlManager = (e.Row.FindControl("ddlManager") as DropDownList);
          DataSet ds = DataBaseConnectivity.GetData
                                     ("select distinct [isManager] from tblUsersTable");
          ddlManager.DataSource = ds; 
          ddlManager.DataTextField = "isManager";
          ddlManager.DataValueField = "isManager";
          ddlManager.DataBind();
          ddlManager.Items.Insert(0, new ListItem("Please select","-1"));
          DataRow row = ((DataRowView)e.Row.DataItem).Row;
          bool isManager= row.Field<bool>("isManager"); // use the correct type if it's not bool
          ddlManager.SelectedValue = isManager.ToString();
