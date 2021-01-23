    private DataTable GetDataTableFromDGV(DataGridView dgv) {
    
        var dt = new DataTable();
        foreach (DataGridViewColumn column in dgv.Columns) {
            if (column.Visible) {
                // You could potentially name the column based on the DGV column name (beware of dupes)
                // or assign a type based on the data type of the data bound to this DGV column.
                dt.Columns.Add();
            }
        }
        object[] cellValues = new object[dgv.Columns.Count];
        foreach (DataGridViewRow row in dgv.Rows) {
            for (int i = 0; i < row.Cells.Count; i++) {
                cellValues[i] = row.Cells[i].Value;
            }
                dt.Rows.Add(cellValues);
        }
        return dt;
    }
