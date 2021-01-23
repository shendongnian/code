	public async Task GetFilesFromDisk()
	{
		StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
		StringBuilder outputText = new StringBuilder();				
		IReadOnlyList<StorageFile> fileList = await picturesFolder.GetFilesAsync();	
		var images = new List<BitmapImage>();
		if (fileList != null)
		{
			foreach (StorageFile file in fileList)
			{
				string cExt = file.FileType;
				if (cExt.ToUpper() == ".JPG") 
				{
					Windows.Storage.Streams.IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
					using (Windows.Storage.Streams.IRandomAccessStream filestream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
					{
						BitmapImage bitmapImage = new BitmapImage();
						await bitmapImage.SetSourceAsync(fileStream);
					}
				}
			}	// ForEach
		}
	}
