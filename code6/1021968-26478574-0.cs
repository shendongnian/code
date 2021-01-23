		public async void ReadTextFile(string cFile)
		{
			var folder = KnownFolders.PicturesLibrary;
			var file = await folder.GetFileAsync(cFile);
			var read = await FileIO.ReadTextAsync(file);
			CurrentFileBuffer = read;
		}
		
