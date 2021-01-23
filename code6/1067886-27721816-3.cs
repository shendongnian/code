        SP.File file = Context.Web.GetFileById(documentGuid);
        SP.ListItem item = file.ListItemAllFields;
        var list = item.ParentList;
        Context.Load(list, l => l.Title, l => l.RootFolder);
        Context.Load(item);
        Context.ExecuteQuery(); //<- submit a single batch query
