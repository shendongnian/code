    public void GridViewCustomDate_DataBound(object send, EventArgs e)
    {
         for (int i = 0; i < GridViewCustomDate.Rows.Count; i++)
         {
             if( condition) // the condition for which you want to check true of false
            GridViewCustomDate.Rows[i].Cells[7].Visible = false; //the cells[7] indicates the last cell. replace with appropriate cell number.
         }
    }
