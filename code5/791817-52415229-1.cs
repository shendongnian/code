    void SafelyCreateZipFromDirectory(string sourceDirectoryName, string zipFilePath)
    {
    	using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
    	using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
    	{
    		foreach (var file in Directory.GetFiles(sourceDirectoryName, "*", SearchOption.AllDirectories))
    		{
    			var entryName = file.Substring(sourceDirectoryName.Length).TrimStart(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar});
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
