    // 1. select the row
    // 2. create a new TableRow object
    // 3. serialize it
    var filteredRow = table.Select("ID=12");
    if (filteredRow.Length == 1)
    {
        var json3 = JsonConvert.SerializeObject(
            new TableRow(filteredRow[0].ItemArray));
    }
