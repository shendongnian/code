    using (FileStream fs = new FileStream(path, FileMode.Open))
    using (ZipArchive zip = new ZipArchive(fs) )
    {
        var entry = zip.Entries.First();
        using (StreamReader sr = new StreamReader(entry.Open()))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
