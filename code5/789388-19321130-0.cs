    var columnsToRemove = table.Columns.Cast<DataColumn>()
        .Where(col => !columnInfos.Any(ci => ci.ColumnName == col.ColumnName))
        .ToList();
    foreach(DataColumn col in columnsToRemove)
        table.Columns.Remove(col);
