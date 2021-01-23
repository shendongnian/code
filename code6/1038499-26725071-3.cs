    string[] lines = File.ReadAllLines(@"c:\bleh\testdata.txt");
    List<Item> allItems = new List<Item>(lines.Length);
    Dictionary<string, List<Item>> itemsByLocation = new Dictionary<string, List<Item>>(StringComparer.OrdinalIgnoreCase);
    // loop the file, start at 1 assuming headings first row
    for (int i = 1; i < lines.Length; i++)
    {
        // nothing interesting here, just parsing the file
        string[] columns = lines[i].Split(new char[] { '\t' });                
        Item item = new Item() { 
            Designator = columns[ORDINAL_DESIGNATOR], 
            MaxPn = columns[ORDINAL_MAXPN], 
            Footprint = columns[ORDINAL_FOOTPRINT], 
            Location = columns[ORDINAL_LOCATION] };
        allItems.Add(item);
        List<Item> itemsForThisKey = null;
        if (itemsByLocation.TryGetValue(item.Location, out itemsForThisKey) == false)
        {
            // we don't already have this location in the dictionary, add it
            itemsForThisKey = new List<Item>();
            itemsByLocation.Add(item.Location, itemsForThisKey);
        }
        itemsForThisKey.Add(item); // add this item to the relevant grouping
    }
    // obligatory answer in linq
    var itemsByLocationWithLinq = from singleItem in allItems
                        group singleItem by singleItem.Location into groupedItems
                        select new { Location = groupedItems.Key, Items = groupedItems.ToList() };
    // now you have your groups so you can do with them as you will
    foreach (var itemLocation in itemsByLocationWithLinq)            
        Console.WriteLine("Linq: {0} has {1:#,0} items", itemLocation.Location, itemLocation.Items.Count);
            
    foreach (var itemLocation in itemsByLocation.Keys)
        Console.WriteLine("Dictionary: {0} has {1:#,0} items", itemLocation, itemsByLocation[itemLocation].Count);            
