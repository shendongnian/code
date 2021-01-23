    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
                  
                Control ctl = e.CommandSource as Control;
                GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;
        
                    if (e.CommandName == "Update")
                    {
        
                        int ID = Convert.ToInt32(GridView1.DataKeys[CurrentRow.RowIndex][0]);
                    }
        
                   if (e.CommandName == "Delete")
                    {
        
                        int ID = Convert.ToInt32(GridView1.DataKeys[CurrentRow.RowIndex][0]);
        
                    }
        }
