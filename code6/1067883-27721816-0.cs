    SP.File file = Context.Web.GetFileById(documentGuid);
    Context.Load(file);
    Context.ExecuteQuery();
    if (file.ServerObjectIsNull != null)
    {
        //File has been loaded..
    }
