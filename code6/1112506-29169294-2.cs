    public static void CopyFile(ClientContext sourceCtx, string sourceFileUrl, ClientContext targetCtx, string targetFileUrl)
    {
        if (sourceCtx.HasPendingRequest)
           sourceCtx.ExecuteQuery();
        using (var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(sourceCtx, sourceFileUrl))
        {
            Microsoft.SharePoint.Client.File.SaveBinaryDirect(targetCtx, targetFileUrl, fileInfo.Stream, true);
        }
    }
