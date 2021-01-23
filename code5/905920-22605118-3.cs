    using (FileStream fs = new FileStream(path, FileMode.Open))
    using (ZipArchive zip = new ZipArchive(fs) )
    {
        var entry = zip.Entries.First();
        //assuming it's a simple text file
        using (StreamReader sw = new StreamReader(entry.Open()))
        {
            Console.WriteLine(sw.ReadToEnd());
        }
    }
