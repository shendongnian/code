    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
    	UpdateCellValue(e.RowIndex);
    }
    private void UpdateCellValue(int CurrentRowIndex)
    {
        if (CurrentRowIndex < 0)
            return;
    	dataGridView1.Rows[CurrentRowIndex].Cells[0].Value = true;
    	dataGridView1.EndEdit();
    	if (CurrentRowIndex > -1)
    	{
    		for (int row = 0; row < dataGridView1.Rows.Count; row++)
    		{
    			if (CurrentRowIndex != row)
    				dataGridView1.Rows[row].Cells[0].Value = false;
    		}
    	}            
    }
