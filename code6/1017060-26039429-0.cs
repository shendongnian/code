    public void onCellContentClick(DataGridViewCellEventArgs cell)
    {
       // Check whether selected cell is check box column, here 0 indicates the check box column.
	   if (cell.ColumnIndex == 0)   
	   {
		  bool isChecked = (Boolean) dataGridView[cell.ColumnIndex, cell.RowIndex].EditedFormattedValue;
		
		  if(isChecked) 
		  {
            // Below will give you the selected cell row index, for multiple rows you can populate those index in list or whatever you convenient with.
			cell.RowIndex;
		  }
	    }
    }
