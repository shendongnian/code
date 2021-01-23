    var file = Context.Web.GetFileById(documentGuid);
    Context.Load(file,i => i.ListItemAllFields);
    Context.ExecuteQuery();
    var folder = Context.Web.GetFolderByServerRelativeUrl((string)file.ListItemAllFields["FileDirRef"]);
    Context.Load(folder);
    Context.ExecuteQuery();
