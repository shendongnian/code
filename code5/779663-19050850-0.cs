    if (e.ColumnIndex.Equals("column Index of Quantity"))
         {
            double total = Convert.ToDouble(dataGridView1["Subtotal column", e.RowIndex].Value) * Convert.ToDouble(dataGridView1["Quantity column", e.RowIndex].Value);
            dataGridView1["Total Column", e.RowIndex].Value = total.ToString();
         }
