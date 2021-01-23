	public Folder GetFolder(string path)
	{
		FolderView fview = new FolderView(100);
		fview.PropertySet = new PropertySet(BasePropertySet.IdOnly);
		fview.PropertySet.Add(FolderSchema.DisplayName);
		fview.Traversal = FolderTraversal.Shallow;
		SearchFilter filter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName, path);
		
		var fldrs = exchange.FindFolders(WellKnownFolderName.PublicFoldersRoot, filter, fview);
		if (fldrs != null)
			return fldrs.FirstOrDefault();
	}
