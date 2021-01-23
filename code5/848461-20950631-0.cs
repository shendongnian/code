    var subListItemsById = subListItems.ToDictionary(x => x.ID);
    listItem.Select(item => 
    {
        SubListItem subListItem;
        if(subListItemsById.TryGetValue(item.ID, out subListItem))
        {
            item.FIELD_1 = subListItem.FIELD_1;
            item.FIELD_2 = subListItem.FIELD_2;
            item.FIELD_3 = subListItem.FIELD_3;
            item.FIELD_4 = subListItem.FIELD_4;
        }
    }).ToList();
