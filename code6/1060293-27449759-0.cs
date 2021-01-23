    string tempFile = Path.GetTempFileName();
    using (ZipArchive original =
        new ZipArchive(File.Open(archiveFileStream, FileMode.Open), ZipArchiveMode.Read))
    using (ZipArchive newArchive =
        new ZipArchive(File.Open(tempFile, FileMode.Create), ZipArchiveMode.Create))
    {
        foreach (ZipArchiveEntry entry in original.Entries)
        {
            ZipArchiveEntry newEntry = newArchive.Create(entry.FullName);
            using (Stream source = entry.Open())
            using (Stream destination = newEntry.Open())
            {
                source.CopyTo(destination);
            }
        }
        for (int directoryGroupFileIndex = 0;
                directoryGroupFileIndex < directoryGroup.Length;
                directoryGroupFileIndex++)
        {
            FileInfo file = directoryGroup[directoryGroupFileIndex];
            String archiveEntryName = file.Name;
            String archiveEntryPath = DateTime.Now.ToString("yyyy-MM-dd");
            String archiveEntryFullName = Path.Combine(archiveEntryPath, archiveEntryName);
    
            ZipArchiveEntry archiveEntry = newArchive.CreateEntryFromFile(
                file.FullName, archiveEntryFullName, CompressionLevel.Optimal);
        }
    }
    File.Delete(archiveFileStream);
    File.Move(tempFile, archiveFileStream);
