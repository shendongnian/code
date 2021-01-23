    using (ZipArchive archive = ZipFile.OpenRead(filePath))
    {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
              // filter archive content if necessary
              if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
              {
                    var extractPath = Path.Combine("Attachments", entry.FullName);
                    entry.ExtractToFile(extractPath, true);
    
                    // Process file
                    DoSomethingWithTheFile(extractPath);
              }
        }
    }
