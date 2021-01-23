    int TotalPositiveValues = 0;
    foreach (DataColumn NextColumn in MyDataTable.Columns)
    {
        DataRow[] PositiveRows = MyDataTable.Select(NextColumn.ColumnName + " >=0");
        int TotalPositiveValues += PositiveRows.Length;
    }
