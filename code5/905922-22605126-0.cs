    using System.IO;
    using System.IO.Compression;
    // ^^^ requires a reference to System.IO.Compression.dll
    static class Program
    {
        const string path = ...
        static void Main()
        {
            using(var file = File.OpenRead(path))
            using(var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach(var entry in zip.Entries)
                {
                    using(var stream = entry.Open())
                    {
                        // do whatever we want with stream
                        // ...
                    }
                }
            }
        }
    }
