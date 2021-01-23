    var copyDt = new DataTable();
    for (var i = 0; i < 11; i++)
    {
        copyDt.Columns.Add(dataTable.Columns[i].ColumnName, dataTable.Columns[1].DataType);
    }
    copyDt.BeginLoadData();
    foreach (DataRow dr in dataTable.Rows)
    {
        copyDt.Rows.Add(Enumerable.Range(0, 11).Select(i => dr[i]).ToArray());
    }
    copyDt.EndLoadData();
