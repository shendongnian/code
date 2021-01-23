    private void itemsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        if (e.RowIndex == -1 || e.RowCount == 0)
        {
            return;
        }
        
        for (int i = 0; i < e.RowCount; i++)
        {
            var index = e.RowIndex + i;  //get row index
    
            DataGridViewRow row = itemsDataGridView.Rows[index];
            row.Cells["subTotalCol"].Value = ComputeRowSubTotal(row).ToString("c");
        }
    }
