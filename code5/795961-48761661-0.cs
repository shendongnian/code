    private void dataGridApprovazioni_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        DataGridView dataGridView = (DataGridView)sender;
        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DateTime.MinValue;
        MessageBox.Show("Invalid Date Format", "System Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
    }
