	protected void gvResults_RowCommand(object sender, 
	  GridViewCommandEventArgs e)
	{
		  if (e.CommandName == "Delete")
		  {
			// Retrieve the row index stored in the 
			// CommandArgument property.
			int index = Convert.ToInt32(e.CommandArgument);
			// Retrieve the row that contains the button 
			// from the Rows collection.
			GridViewRow row = gvResults.Rows[index];
			// Add your code here
		  }
	}
