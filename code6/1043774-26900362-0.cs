    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
       
       if(e.ColumnIndex == 2) // quantity column
       {
         int col = e.ColumnIndex;
         int row = e.RowIndex;
         int quantity = Convert.ToInt32(dataGridView1.Rows[row].Cells[col].Value); // entered quantity
         double value = Convert.ToDouble(dataGridView1.Rows[row].Cells[col -1].Value); // value of corresponding row
    
         dataGridView1.Rows[row].Cells[col+1].Value = (quantity*value).ToString();
       }
    }
