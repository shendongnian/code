    using (var context = new ClientContext("http://vddp23q-5d16d1e/"))
    {
        var query = new CamlQuery();
        var list = context.Web.Lists.GetByTitle("Documents");
        int pageSize = 10;
        query.ViewXml = string.Format(
    @"<View><RowLimit Paged='true'>{0}</RowLimit></View>", pageSize);
        ListItemCollection items;
        do
        {
            items = list.GetItems(query);
            context.Load(items);
            context.ExecuteQuery();
            foreach (var item in items)
                DoStuff(item);
            query.ListItemCollectionPosition = items.ListItemCollectionPosition;
        }
        while (items.ListItemCollectionPosition != null);
    }
