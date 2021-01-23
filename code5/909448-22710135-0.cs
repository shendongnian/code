    // add with
    Item item = ...
    foreach (var tag in tagsForItem) {
        List<Item> items;
        if (!dictionary.TryGetValue(tag, out items)) 
        {
           items = dictionary[tag] = new List<Item>();
        }
        items.Add(item)
    }
    
    // lookup with
    var items = dictionary[tag];
