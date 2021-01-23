    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        { 
              // Show in messagebox
               MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
              // Set the value to string
              String value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
            }
        }
 
