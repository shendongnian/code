    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	UpdateCellValue(e.RowIndex);
    }
    private void UpdateCellValue(int CurrentRowIndex)
    {
    	if (CurrentRowIndex > -1)
    	{
    		bool bVal = (bool)dataGridView1.Rows[CurrentRowIndex].Cells[0].Value;
    		for (int row = 0; row < dataGridView1.Rows.Count; row++)
    		{
    			if (CurrentRowIndex != row)
    				dataGridView1.Rows[row].Cells[0].Value = false;
    		}
    	}
    }
