    List<Item> GetAffectedItems(Item item)
    {
        List<Item> list = new List<Item>();
        GetAffectedItems(item, list);
        return list;
    }
    void GetAffectedItems(Item item, List<Item> list)
    {
        foreach (Item affectedItem in item.affectedItems)
        {
            GetAffectedItems(affectedItem, list);
        }
        list.Add(item);
    }
