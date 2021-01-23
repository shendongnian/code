    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            string fileAddr = Path.Combine(extractPath, entry.FullName);
            string dirAddr = System.IO.Path.GetDirectoryName(fileAddr);
            if (!Directory.Exists(dirAddr))
            {
                Directory.CreateDirectory(dirAddr);
            }
            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
        }
    }
