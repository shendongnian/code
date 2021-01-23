    string[] wantedColumns = { "Column1", "Column2", "Column3" }; // for example
    DataTable secondTable = firstTable.Copy();
    var removeColumns = secondTable.Columns.Cast<DataColumn>()
        .Where(col => !wantedColumns.Contains(col.ColumnName, StringComparer.InvariantCultureIgnoreCase))
        .ToList();
    removeColumns.ForEach(c => secondTable.Columns.Remove(c));
