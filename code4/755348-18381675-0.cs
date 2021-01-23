    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow))
        {
            
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
           
            DropdownList ddlxxx= (DropDownList)e.Row.FindControl("ddlName");               
             //This will make your ddl readonly 
             ddlxxx.Enabled = false;
        }
    }
