    var activeLogFile = Directory.GetFiles(folderName, "*.log").Single();
    var logFiles = Directory.GetFiles(folderName,"*.log.*")
                            .SkipWhile(x=>x==activeLogFile);
    using (var zip = ZipFile.Open(destinationDirectory.DirectoryPath + "Test.zip",
    ZipArchiveMode.Create))
    {
        foreach (var file in logFiles)
        {
            zip.CreateEntryFromFile(file, Path.GetFileName(file),
            CompressionLevel.Optimal);
        }
        using (var stream = new FileStream(activeLogFile, FileMode.Open, 
        FileAccess.Read, FileShare.Delete | FileShare.ReadWrite))
        {
            var zipArchiveEntry = zip.CreateEntry(Path.GetFileName(activeLogFile),
            CompressionLevel.Optimal);
            var dateTime = File.GetLastWriteTime(activeLogFile);
            if (dateTime.Year < 1980 || dateTime.Year > 2107)
                dateTime = new DateTime(1980, 1, 1, 0, 0, 0);
            zipArchiveEntry.LastWriteTime = (DateTimeOffset)dateTime;
            using (var destination1 = zipArchiveEntry.Open())
                stream.CopyTo(destination1);
        }
    }
