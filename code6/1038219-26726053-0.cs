    static void CheckZipEntries(string fileName)
    {
        using (Stream inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
        using (ZipArchive archive = new ZipArchive(inputStream, ZipArchiveMode.Read))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                using (Stream entryStream = entry.Open())
                {
                    Console.WriteLine("Entry length: {0},   Stream length: {1}",
                        entry.Length, GetStreamLength(entryStream));
                }
            }
        }
    }
    static int GetStreamLength(Stream stream)
    {
        int count = 0, bytesRead;
        byte[] rgb = new byte[1024];
        while ((bytesRead = stream.Read(rgb, 0, rgb.Length)) > 0)
        {
            count += bytesRead;
        }
        return count;
    }
