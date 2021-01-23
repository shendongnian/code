    var rowCount = valueArray.GetLength(0);
    var columnCount = valueArray.GetLength(1);
    var dtTemp = new DataTable();
    foreach(var c in Enumerable.Range(1, columnCount)) dtTemp.Columns.Add();
    foreach (var r in Enumerable.Range(1, rowCount))
        dtTemp.Rows.Add(Enumerable.Range(1, columnCount)
            .Select(c => valueArray[r - 1, c - 1]).ToArray());
