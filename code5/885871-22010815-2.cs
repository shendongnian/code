    /// <summary>
    /// Create Folder client object
    /// </summary>
    /// <param name="web"></param>
    /// <param name="listTitle"></param>
    /// <param name="fullFolderUrl"></param>
    /// <returns></returns>
    public static Folder CreateFolder(Web web, string listTitle, string fullFolderUrl)
    {
        if (string.IsNullOrEmpty(fullFolderUrl))
            throw new ArgumentNullException("fullFolderUrl");
        var list = web.Lists.GetByTitle(listTitle);
        return CreateFolderInternal(web, list.RootFolder, fullFolderUrl);
    }
    private static Folder CreateFolderInternal(Web web, Folder parentFolder, string fullFolderUrl)
    {
        var folderUrls = fullFolderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        string folderUrl = folderUrls[0];
        var curFolder = parentFolder.Folders.Add(folderUrl);
        web.Context.Load(curFolder);
        web.Context.ExecuteQuery();
        if (folderUrls.Length > 1)
        {
            var nextFolderUrl = string.Join("/", folderUrls, 1, folderUrls.Length - 1);
            return CreateFolderInternal(web, curFolder, nextFolderUrl);
        }
        return curFolder;
    }
