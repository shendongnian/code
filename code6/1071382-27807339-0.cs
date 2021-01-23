    Directory
    .GetFiles(@"[Path of your root directory]", "*.*", SearchOption.AllDirectories)
    .Where(item =>
    {
        try
        {
            var fileInfo = new FileInfo(item);
            return fileInfo.CreationTime < DateTime.Now.AddHours(-24);
        }
        catch (Exception)
        {
            return false;
        }
    })
    .ToList()
    .ForEach(File.Delete);
