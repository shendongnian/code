    public DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
    {
        DataTable dataTable = new DataTable();
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            //// I assume you need all your columns.
            dataTable.Columns.Add(column.Name, column.CellType);
        }
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            //// If the value of the column with the checkbox is true at this row, we add it
            if (row.Cells["checkbox column name"].Value == true)
            {
                object[] values = new object[dataGridView.Columns.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    values[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(values);
            }
        }
        return dataTable;
    }
