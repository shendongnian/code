    public static void RenameFile(ClientContext ctx,string fileUrl,string newName)
    {
            var file = ctx.Web.GetFileByServerRelativeUrl(fileUrl);
            ctx.Load(file.ListItemAllFields);
            ctx.ExecuteQuery();
            file.MoveTo(file.ListItemAllFields["FileDirRef"] + "/" + newName, MoveOperations.Overwrite); 
            ctx.ExecuteQuery();
    }
