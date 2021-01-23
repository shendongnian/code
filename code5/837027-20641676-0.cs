    foreach (string columnName in columnList)
    {
        var columnData = dt.AsEnumerable().Select(x => x.Field<double>(columnName));
        //creates a NormalData object for each column in the DataTable
        NormalData normalData = new NormalData();
        normalData.Mean = columnData.Average();
        normalData.StandardDeviation = StdDev(columnData);
        normalData.AttributeName = columnName;
        //add to NormalDataList
        normalDataList.Add(normalData);
    }
