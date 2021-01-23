    // Somewhere... Only once, not every time you want to add new items
    // In fact, there shouldn't be any CurrentCol, only the dictionary.
    var currentItems = CurrentCol.ToDictionary(x => x.MSISDN, x => x);
    
    // ...
    
    foreach(var newItem in NewCol)
    {
        PortedNumberCollection existingItem;
        if(currentItems.TryGetValue(newItem.MSISDN, out existingItem)
        {
            existingItem.RouteAction = newItem.RouteAction;
            existingItem.RoutingLabel = newItem.RoutingLabel;
        }
        else
        {
            currentItems.Add(newItem.MSISDN, newItem);
        }
    }
