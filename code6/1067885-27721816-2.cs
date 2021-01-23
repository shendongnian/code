    var file = Context.Web.GetFileById(documentGuid);
    var item = file.ListItemAllFields;
    Context.Load(item.ParentList, l => l.RootFolder);
    Context.ExecuteQuery();
    var listUrl = item.ParentList.RootFolder.ServerRelativeUrl;
