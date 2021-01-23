    protect void RowDataboundEventHandler(object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
        {
          // Get value from column directly
          string value =  e.Row.Cells[1].Text;
    
          // if you want to find control value
          e.Row.FindControl("controlID");
        }
    }
