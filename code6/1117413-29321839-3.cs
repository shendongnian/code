    if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
    
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddl");
                ddl.DataTextField = "Name";
                ddl.DataValueField = "CategoryID";
                ddl.Items.Clear();//add this line
                ddl.DataSource = Seminar_ListDB.getAllSemList();
                ddl.DataBind();
                
                ddl.SelectedValue = drv["CategoryID"].ToString();
            }
        }
