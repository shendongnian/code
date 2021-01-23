    var query = tempItems.AsQueryable();
    switch(itemType)
    {
       case ItemType.Damaged:
            query.Join(...);
            break;
       case ItemType.Fixed:
            query.Where(...);
    }
    query.Select(e => new ItemDto{//Lots of properties});
    return query.ToList();
