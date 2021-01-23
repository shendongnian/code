    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    
    {
        if (e.CommandName == "selectImage")
        {
    
            int rowIndex = Convert.ToInt32(e.CommandArgument); // Get the current row
            int cellVal = Convert.ToInt32(grdView.Rows[rowIndex].Cells[2].Text);//Get the cell value
    
            Response.Write(cellVal.ToString());
    
        }
    }
