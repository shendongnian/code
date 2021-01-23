    DataTable table = new DataTable();
    foreach (DataRow row in table.Columns) {
        foreach (DataColumn col in table.Columns) {
            object value = row[col.ColumnName];
        }
    }
