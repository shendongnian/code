    var rowCount = valueArray.GetLength(0);
    var columnCount = valueArray.GetLength(1);
    var dtTemp = new DataTable();
    Enumerable.Range(1, columnCount).Each(c => dtTemp.Columns.Add());
    Enumerable.Range(1, rowCount)
        .Each(r => dtTemp.Rows.Add(
            Enumerable.Range(1, columnCount)
            .Select(c => valueArray[r - 1, c - 1])
            .ToArray()
        ));
