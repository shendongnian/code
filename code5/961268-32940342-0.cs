     private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex.Equals("column Index of Quantity"))
        {
            double total = Convert.ToDouble(dataGridView1["Subtotal column name", e.RowIndex].Value) * Convert.ToDouble(dataGridView1["Quantity column name", e.RowIndex].Value);
            dataGridView1["Total Column name", e.RowIndex].Value = total.ToString();
        }            
    }
