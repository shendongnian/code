    CellFeed cellFeed = spreadsheetService.Query(cellQuery);
    int i = 1;
    foreach (string value in values)
    {
       CellEntry entry = cellFeed[1, i++];
       entry.InputValue = value;
       entry.Etag = "*";
    }
    cellFeed.Publish();
