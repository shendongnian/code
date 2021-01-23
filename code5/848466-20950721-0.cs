    var subItemLookup = subItems.ToDictionary(i => i.Id);
    foreach (var item in items)
    {
        SubItem subItem;
        if (subItemLookup.TryGetValue(item.Id, out subItem))
        {
            item.Field1 = subItem.Field1;
            //etc.
        }
    }
