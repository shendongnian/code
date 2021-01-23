    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "DeleteItem")
      {
        // Retrieve the row index stored in the 
        // CommandArgument property.
        int index = Convert.ToInt32(e.CommandArgument);
        // Retrieve the row that contains the button 
        // from the Rows collection.
         GridViewRow row = GridView1.Rows[index];
        //Retrieve the key of the row and delete the item
        
      }
      else if(e.CommandName == "EditItem")
      {
        //edit the item
      }
      //Other commands
    }
