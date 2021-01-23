    void SafelyCreateZipFromDirectory(string sourceDirectoryName, string zipFilePath)
    {
    	using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
    	using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
    	{
    		foreach (var file in Directory.GetFiles(sourceDirectoryName))
    		{
    			var entryName = Path.GetFileName(file);
    			var entry = archive.CreateEntry(entryName);
    			entry.LastWriteTime = File.GetLastWriteTime(file);
    			using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    			using (var stream = entry.Open())
    			{
    				fs.CopyTo(stream, 81920);
    			}
    		}
    	}
    }
