    listMatchedItems.ItemsSource = list1.Intersect(list2).ToList();
    listMachedItemsCount = listMatchedItems.Count();
    
    listNotMatchedItems.ItemsSource = list1.Except(list2).ToList();
    listNotMachedItemsCount = listNotMatchedItems.Count();
