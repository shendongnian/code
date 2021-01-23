    var rct3Features = new Dictionary<string, List<string>>();
    var rct4Features = new Dictionary<string, List<string>>();
    foreach (string line in rct3Lines)
    {
        string[] items = line.Split(new String[] { " " }, 2, StringSplitOptions.None);
        if (!rct3Features.ContainsKey(items[0]))
        {
            // No items for this key have been added, so create
            // a new list with this item for the value
            rct3Features.Add(items[0], new List<string> { items[1] });
        }
        else
        {
            // This key already exists, so add this item to the existing list value
            rct3Features[items[0]].Add(items[1]);
        }
    }
    // To display your keys and values (testing)
    foreach (KeyValuePair<string, List<string>> item in rct3Features)
    {
        Console.WriteLine("The Key: {0} has values:", item.Key);
        foreach (string value in item.Value)
        {
            Console.WriteLine(" - {0}", value);
        }
    }
