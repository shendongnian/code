    var itemCollection = MapExtensions.GetChildren((Map)MyMap)
                                      .OfType<MapItemsControl>().FirstOrDefault();
    if(itemCollection != null && itemCollection.Items.Count >0)
    {
        itemCollection.Items.Clear();
    }
    foreach(var item in YourPushpinCollection)
    {
        itemCollection.Items.Add(item);
    }
