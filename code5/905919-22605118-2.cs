    using (FileStream fs = new FileStream(path, FileMode.Open))
    using (ZipArchive zip = new ZipArchive(fs) )
    {
        var entry = zip.Entries.First();
        using (StreamReader sw = new StreamReader(entry.Open()))
        {
            Console.WriteLine(sw.ReadToEnd());
        }
    }
