    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "view")
      {
         // Retrieve the row index
         int index = Convert.ToInt32(e.CommandArgument);
         // Retrieve the row by its index
         GridViewRow row = this.GridView1.Rows[index];
        // Add code get the cell value from the row
        string cellValue = r.Cells[0].Text;
      }
   }
