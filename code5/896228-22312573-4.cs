    DataColumn[] aCols = table.Columns.Cast<DataColumn>()
        .Where(c => c.ColumnName.EndsWith("A"))
        .Select(c => new DataColumn(c.ColumnName, c.DataType))
        .ToArray();
    DataColumn[] bCols = table.Columns.Cast<DataColumn>()
        .Where(c => c.ColumnName.EndsWith("B"))
        .Select(c => new DataColumn(c.ColumnName, c.DataType))
        .ToArray();
    var TableA = new DataTable();
    TableA.Columns.AddRange(aCols);
    var TableB = new DataTable();
    TableB.Columns.AddRange(bCols);
    foreach (DataRow row in table.Rows)
    { 
        DataRow aRow = TableA.Rows.Add();
        DataRow bRow = TableB.Rows.Add();
        foreach (DataColumn aCol in aCols)
            aRow.SetField(aCol, row[aCol.ColumnName]);
        foreach (DataColumn bCol in bCols)
            bRow.SetField(bCol, row[bCol.ColumnName]);
    }
