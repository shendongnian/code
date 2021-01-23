    protected void GridView1_RowCommand(object sender, 
                             GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Delete")
      {
        // get the primary key id of the clicked row
        int id= Convert.ToInt32(e.CommandArgument);
        // Delete the record 
        DeleteRecordByPrimaryKey(id);// Implement this on your own :) 
        
      }
    }
