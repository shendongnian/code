    private void DataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
    {
    	//second column
    	if (e.ColumnIndex == 1) {
    		object value = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value;
    		if (value != null && value.ToString != string.Empty) {
    			DataGridView1.Rows(e.RowIndex).Cells(2).ReadOnly = false;
    		} else {
    			DataGridView1.Rows(e.RowIndex).Cells(2).ReadOnly = true;
    		}
    	}
    }
