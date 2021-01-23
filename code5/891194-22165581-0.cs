    private void OnUrlChanged(string newUrl)
	{
		if (string.IsNullOrEmpty(newUrl))
			return;
                
        //instantiate only once
		if (FoldersDictionary == null)
		{
			FoldersDictionary = new Dictionary<DirectoryInfo,   ObservableCollection<Media>>();
		}
		else if (FoldersDictionary.Any())
		{
			FoldersDictionary.Clear();
		}
		var directoryInfo = new DirectoryInfo(newUrl);
		DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
		if (directoryInfos.Any())
		{                
			LoadFolders(FoldersDictionary, directoryInfos);
		}
	}
