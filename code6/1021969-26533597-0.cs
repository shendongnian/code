	public async Task WriteDataToFileAsync(string fileName, string content)
	{
		byte[] data = System.Text.Encoding.Unicode.GetBytes(content);
		var folder = KnownFolders.PicturesLibrary;
		var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
		using (var s = await file.OpenStreamForWriteAsync())
		{
			await s.WriteAsync(data, 0, data.Length);
		}
	}
