    Dictionary<int, PageItem> Items = new Dictionary<int, PageItem>();
    while (rdr.Read())
    {
        var item = new PageItem()
        {
            Id = Convert.ToInt32(rdr["Id"]),
            ParentId = Convert.ToInt32(rdr["ParentId"]),
            MenuText = rdr["MenuTitle"].ToString(),
            Childs = new List<PageItem>()
        };
        Items[item.Id] = item;
    }
    foreach (var pair in Items)
    {
        PageItem item = pair.Value;
        if (item.ParentId == 0)
            continue;
        Items[item.ParentId].Childs.Add(item);
    }
