    class ZipFile
    {
    	public string Name { get; set; }
    	public byte[] Data { get; set; }
    }
    ...
    var files = new List<ZipFile>(); //The files to zip
    var zipStream = new MemoryStream(); //Where the zip archive is stored
    
    using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create))
    {
    	foreach (var file in files)
    	{
    		var fileEntry = zipArchive.CreateEntry(file.Name);
    		
    		using (var entryStream = fileEntry.Open())
    		{
    			entryStream.Write(file.Data, 0, file.Data.Length);
    		}
    	}
    }
    
    //You can now send the zip archive as binary data.
