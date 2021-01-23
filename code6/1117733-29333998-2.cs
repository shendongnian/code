    const string dataFilePath = @"d:\public\temp\data.txt";
    string[] fileData = File.ReadAllLines(dataFilePath);
    var numColumns = table.Columns.Count;
    foreach (string dataItem in fileData)
    {
        var items = dataItem.Split(delimiter.ToCharArray()).Take(numColumns);
        table.Rows.Add(items);
    }
