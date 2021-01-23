    foreach (var dataTableCol in this.dataTable.Columns.Cast<DataColumn>().ToList())
    {
        ...
        this.dataTable.Columns.Remove(dataTableCol.ColumnName);
    }
