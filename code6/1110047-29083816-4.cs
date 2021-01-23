    private static List<Item> AddItemLists(List<List<Item>> itemLists)
    {
        if (itemLists == null) throw new ArgumentNullException("itemLists");
        var result = new List<Item>();
        foreach (var itemList in itemLists)
        {
            foreach (var item in itemList)
            {
                var existingItemWithId = result.FirstOrDefault(i => i.Id == item.Id);
                if (existingItemWithId == null)
                {
                    result.Add(item);
                }
                else
                {
                    foreach (var itemData in item.Data)
                    {
                        if (existingItemWithId.Data.ContainsKey(itemData.Key))
                        {
                            existingItemWithId.Data[itemData.Key] += itemData.Value;
                        }
                        else
                        {
                            existingItemWithId.Data.Add(itemData.Key, itemData.Value);
                        }
                    }
                }
            }
        }
        return result;
    }
