    public static Folder GetPublicExchangeFolder(string folderPath, ExchangeService exchange)
    {
      FolderView fview = new FolderView(1);
      fview.PropertySet = new PropertySet(BasePropertySet.IdOnly);
      fview.PropertySet.Add(FolderSchema.DisplayName);
      fview.Traversal = FolderTraversal.Shallow;
      Folder currentFolder = null; FindFoldersResults fldrs;
      string[] folders = folderPath.Split(new char[] { '\\' });
      foreach (string FolderName in folders)
      {
        SearchFilter filter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName, FolderName);
        if(currentFolder==null)
          fldrs = exchange.FindFolders(WellKnownFolderName.PublicFoldersRoot, filter, fview);
        else
          fldrs = currentFolder.FindFolders(filter, fview);
        if ((fldrs == null) || (fldrs.Count()==0))
          return null;
        else
          currentFolder = fldrs.FirstOrDefault();
      }
      return currentFolder;
    }
