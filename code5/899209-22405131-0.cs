    /// <summary>
    /// Get Parent Folder for List Item
    /// </summary>
    /// <param name="listItem"></param>
    /// <returns></returns>
    private static Folder GetListItemFolder(ListItem listItem)
    {
        var folderUrl = (string)listItem["FileDirRef"];
        var parentFolder = listItem.ParentList.ParentWeb.GetFolderByServerRelativeUrl(folderUrl);
        listItem.Context.Load(parentFolder);
        listItem.Context.ExecuteQuery();
        return parentFolder;
    }
