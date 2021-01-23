    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (e.ColumnIndex == *someIndex*)
    	{
    		DataGridViewCheckBoxCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
    		if (cell != null)
    		{
    			if (cell.EditingCellValueChanged)
    			{
    				//CheckBox has been clicked
    			}
    
    			//here how to get the checkBoxCell value
    			var cellChecked = cell.EditingCellFormattedValue;
    		}
    	}
    }
