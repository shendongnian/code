    listMatchedItems.Items.AddRange(list1.Intersect(list2).ToArray());
    listMachedItemsCount = listMatchedItems.Count();
    
    listNotMatchedItems.Items.AddRange(list1.Except(list2).ToArray());
    listNotMachedItemsCount = listNotMatchedItems.Count();
