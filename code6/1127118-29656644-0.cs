Look out for the lines where we're doing a continue.
    public void Mapper(List<Item> items, List<List> lists, List<ListItem> listItems)
    {
        using (var command = Context.CreateCommand())
        {
            command.CommandText = @"SELECT ListItem.ListId, ListItem.ItemId, Item.ItemId AS ItemItemId, List.ListId AS ListListId 
                                        FROM Item INNER JOIN
                                        ListItem ON Item.ItemId = ListItem.ItemId INNER JOIN
                                        List ON ListItem.ListId = List.ListId";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int listid = (int)reader["ListId"];
                    int itemid = (int)reader["ItemId"];
                    int listlistid = (int)reader["ListId"];
                    int itemitemid = (int)reader["ItemItemId"];
                    foreach (var listitem in listItems)
                    {
                        // This is the condition you're missing.
                        if (listitem.ListId != listid &&
                            listitem.ItemId != itemid)
                        {
                            continue;
                        }
                        foreach (var item in items)
                        {
                            if (item.ItemId == itemitemid && itemitemid == itemid)
                            {
                                listitem.Item = item;
                            }
                        }
                        foreach (var list in lists)
                        {
                            if (list.ListId == listlistid && listlistid == listid)
                            {
                                listitem.List = list;
                            }
                        }
                    }
                }
            }
        }
    }
