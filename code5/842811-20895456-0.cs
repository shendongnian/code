    // For WP8, the taken photo inside a app will be automatically saved.
	// So we take the last picture in MediaLibrary.
	using (MediaLibrary library = new MediaLibrary())
	{
		string filePath = "x.jpg";
		MemoryStream fileStream = new MemoryStream();// MemoryStream does not need to call Close()
		Picture photoFromLibrary = library.Pictures[library.Pictures.Count - 1];// Get last picture
		Stream stream = photoFromLibrary.GetImage();
		stream.CopyTo(fileStream);
		SaveMemoryStream(fileStream, filePath);
	}
	private void SaveMemoryStream(MemoryStream ms, string path)
	{
		try
		{
			using (var isolate = IsolatedStorageFile.GetUserStoreForApplication())
			{
				using (IsolatedStorageFileStream file = new IsolatedStorageFileStream(path, FileMode.Create, FileAccess.Write, isolate))
				{
					ms.WriteTo(file);
				}
			}
		}
		finally
		{
			IsolatedStorageMutex.ReleaseMutex();
		}
	}
