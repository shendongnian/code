    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
    {
        foreach (ZipArchiveEntry entry in archive.Entries.Where(e => e.FullName.Containts("a")))
        {
            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
        }
    } 
