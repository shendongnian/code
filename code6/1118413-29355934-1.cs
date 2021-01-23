    using (FileStream zipToOpen = new FileStream(
               @"c:\users\exampleuser\release.zip", FileMode.Open))
    {
        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
        {
            ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
            {
                    writer.WriteLine("Information about this package.");
                    writer.WriteLine("========================");
            }
        }
    }
