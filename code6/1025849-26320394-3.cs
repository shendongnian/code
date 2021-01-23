    var srcFolderUrl = "/news/pages";
    var destFolderUrl = "/news/archive/pages";
    using (var ctx = new ClientContext(url))
    {      
        var sourceFolder = ctx.Web.GetFolderByServerRelativeUrl(srcFolderUrl);
        sourceFolder.MoveFilesTo(destFolderUrl);
        sourceFolder.DeleteObject(); // delete source folder if nessesary
        ctx.ExecuteQuery();
    }
 
