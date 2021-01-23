    public void ConfigureColumns(DataTable dataTable, params String[] columnNames)
    {
        var _dataGridView = new DataGridView();
        HashSet<String> columns = new HashSet<String>(columnNames);
        foreach (DataColumn column in dataTable.Columns)
        {
            var colName = column.ColumnName;
            if (columns.Contains(colName)) 
            {
                var newColumn = new DataGridViewTextBoxColumn() {Name = columnName, Visible = true};
                _dataGridView.Columns.Add(newColumn);
            }
        }
    }
