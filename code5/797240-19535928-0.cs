    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        if (e.RowIndex == -1 || e.RowCount == 0)
        {
            return;
        }
    
        for (int i = 0; i < e.RowCount; i++)
        {
            var index = e.RowIndex + i;
    
            var row = DGV_ActivityDtls.Rows[index];
            row.Cells[0].Value = "Activities";
            row.Cells[1].Value = " ";
            row.Cells[2].Value = "LT";
        }
    }
