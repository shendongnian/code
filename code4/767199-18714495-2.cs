    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        string fullPath = Path.Combine(extractPath, entry.FullName);
        if (String.IsNullOrEmpty(entry.Name))
        {
            Directory.CreateDirectory(fullPath);
        }
        else
        {
            if (!entry.Name.Equals("please dont extract me.txt"))
            {
                entry.ExtractToFile(fullPath);
            }
        }
    }
