    var files = Directory.EnumerateFiles(directoryPath, "*.mp3", SearchOption.AllDirectories);
    foreach (var item in files)
    {
       try
       {
           File.Delete(item);
       }
       catch (Exception)
       { //log exception}
    }
