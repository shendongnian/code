         protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = e.Row.Cells[4].FindControl("DropDownList2") as DropDownList;
            if (ddl != null)
            {
                // if (your_condition == true)
                //{
                        ddl .Visible = false;
                        
                //}
    
            }
        }
    }
