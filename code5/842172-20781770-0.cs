    private int RowNumber=0; // Define at the top
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          
          RowNumber += 1;
       }
    	// you need to add one label at Footer section
       if (e.Row.RowType == DataControlRowType.Footer)
       {
          Label lblTotalRow = (Label)e.Row.FindControl("lblTotalRow");
          lblTotalRow.Text = RowNumber.ToString();
       }
    }
