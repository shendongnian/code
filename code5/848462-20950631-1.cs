    var itemsById = listItem.ToDictionary(x => x.ID);
    foreach(var subListItem in subListItems)
    {
        Item item;
        if(itemsById.TryGetValue(subListItem.ID, out item))
        {
            item.FIELD_1 = subListItem.FIELD_1;
            item.FIELD_2 = subListItem.FIELD_2;
            item.FIELD_3 = subListItem.FIELD_3;
            item.FIELD_4 = subListItem.FIELD_4;
        }	
    }
    var modifiedItems = itemsById.Values;
