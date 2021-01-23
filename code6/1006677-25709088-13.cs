    public static void UploadFile(ClientContext context,string uploadFolderUrl, string uploadFilePath)
    {
        var fileCreationInfo = new FileCreationInformation
        {
                Content = System.IO.File.ReadAllBytes(uploadFilePath),
                Overwrite = true,
                Url = Path.GetFileName(uploadFilePath)
        };
        var targetFolder = context.Web.GetFolderByServerRelativeUrl(uploadFolderUrl);
        var uploadFile = targetFolder.Files.Add(fileCreationInfo);
        context.Load(uploadFile);
        context.ExecuteQuery();
    }
