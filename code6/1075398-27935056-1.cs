    foreach (var dataTableCol in dataTable.Columns.Cast<DataColumn>().ToList())
    {
        ...
        dataTable.Columns.Remove(dataTableCol.ColumnName);
    }
