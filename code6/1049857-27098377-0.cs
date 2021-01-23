    Dictionary<string, string> Values = new Dictionary<string, string>();
    using (var memoryStream = new MemoryStream())
    {
        string zip = @"C:\Temp\ZipFile.zip";
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            foreach (var item in Values)
            {
                var file = archive.CreateEntry(item.Key + ".txt");
                using (var entryStream = file.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    streamWriter.Write(item.Value);
                }
            }
        }
        
        using (var fileStream = new FileStream(zip, FileMode.Create))
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.CopyTo(fileStream);
        }
    }
