    /// <summary>
    /// Create Folder client object
    /// </summary>
    /// <param name="web"></param>
    /// <param name="listTitle"></param>
    /// <param name="fullFolderPath"></param>
    /// <returns></returns>
    public static Folder CreateFolder(Web web, string listTitle, string fullFolderPath)
    {
        if (string.IsNullOrEmpty(fullFolderPath))
            throw new ArgumentNullException("fullFolderPath");
        var list = web.Lists.GetByTitle(listTitle);
        return CreateFolderInternal(web, list.RootFolder, fullFolderPath);
    }
    private static Folder CreateFolderInternal(Web web, Folder parentFolder, string fullFolderPath)
    {
        var folderUrls = fullFolderPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        string folderUrl = folderUrls[0];
        var curFolder = parentFolder.Folders.Add(folderUrl);
        web.Context.Load(curFolder);
        web.Context.ExecuteQuery();
        if (folderUrls.Length > 1)
        {
            var folderPath = string.Join("/", folderUrls, 1, folderUrls.Length - 1);
            return CreateFolderInternal(web, curFolder, folderPath);
        }
        return curFolder;
    }
