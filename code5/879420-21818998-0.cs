    private void DataGridView_CellFormatting(object sender,
    				System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
    	// Check if this is in the column you want.
    	if (dataGridView1.Columns[e.ColumnIndex].Name == "ColumnName")
    	{
    		// Check if the value is large enough to flag.
    		if (Convert.ToInt32(e.Value).Tostring == "HIGH")
    		{
    			//Do what you want with the cell lets change color
    			e.CellStyle.ForeColor = Color.Red;
    			e.CellStyle.BackColor = Color.Yellow;
    			e.CellStyle.Font =
    			new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
    		}
    	}
    }
