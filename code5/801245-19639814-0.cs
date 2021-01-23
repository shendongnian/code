    DataTable dt = new DataTable();
    foreach (DataGridViewColumn column in dataGridView1.Columns)
        dt.Columns.Add(column.Name, column.CellType); //better to have cell type
    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
    {
         dt.Rows.Add();
         for (int j = 0; j < dataGridView1.Columns.Count; j++)
         {
             dt.Rows[i][j] = dataGridView1.SelectedRows[i].Cells[j].Value;
                                       //^^^^^^^^^^^
         }
     }
