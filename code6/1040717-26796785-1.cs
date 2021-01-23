    // Items to find
    int[] itemIds = {1513, 1514, 1515, 1516, 1517};
    // Create blank list
    List<Item> items = new List<Item>();
    foreach (int id in itemIds)
    {
        var n = new WebClient();
        // Get JSON
        var json = n.DownloadString("http://services.runescape.com/m=itemdb_rs/api/catalogue/detail.json?item=1513");
        // Parse to Item object
        var item = JsonConvert.DeserializeObject<Item>(json);
        // Append to list
        items.Add(item);
    }
    // Do something with list
