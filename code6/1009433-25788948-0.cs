    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
         if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
         {
            DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
            if (cbCell.Value == cbCell.TrueValue)
            {
                cbCell.Value = cbCell.FalseValue;
            }
            else
            {
                cbCell.Value = cbCell.TrueValue;
            }
          }
    }
