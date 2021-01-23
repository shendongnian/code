    DataTable table = new DataTable();
    string[] columns = table.Columns.Cast<DataColumn>()
                                    .Select(x => x.ColumnName)
                                    .ToArray();
    var invalidRows = table.AsEnumerable()
        .Where(x => columns.All(c => x.Field<object>(c) == DBNull.Value))
        .ToArray();
    foreach (var row in invalidRows)
    {
        table.Rows.Remove(row);
    }
