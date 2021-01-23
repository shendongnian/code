    private static void DownloadFile(Web web, string fileUrl,string targetPath)
    {
        var ctx = (ClientContext)web.Context;
        ctx.ExecuteQuery();
        using(var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, fileUrl))
        {
             var fileName = Path.Combine(targetPath, System.IO.Path.GetFileName(fileUrl));
             using (var fileStream = System.IO.File.Create(fileName))
             {
                 fileInfo.Stream.CopyTo(fileStream);
             }
        }
    }
