    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        DropDownList ddl = e.Row.Cells[4].FindControl("DropDownList2") as DropDownList;
		Label lblddl = e.Row.Cells[4].FindControl("gvlblddlVal") as Label;
        if (!string.IsNullOrEmpty(lblddl.Text))
        {            
                    ddl.Visible = false;
					lblddl.Visible = true;           
        }
        else
        {
                    ddl.Visible = true;
					lblddl.Visible =false; 
         }
      }
    }
