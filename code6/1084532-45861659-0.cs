    class Program
    {
        const string zipFile = @"D:\downloads\price.zip";
    
        static void Main(string[] args)
        {
            using (Stream stream = File.OpenRead(zipFile))
            {
                string dllPath = Environment.Is64BitProcess ?
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z64.dll")
                        : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7z.dll");
    
                SevenZipBase.SetLibraryPath(dllPath);
    
                Extract(stream);
            }
        }
    
        static void Extract(Stream archiveStream)
        {
            using (SevenZipExtractor extr = new SevenZipExtractor(archiveStream))
            {
                foreach (ArchiveFileInfo archiveFileInfo in extr.ArchiveFileData)
                {
                    if (!archiveFileInfo.IsDirectory)
                    {
                        using (var mem = new MemoryStream())
                        {
                            extr.ExtractFile(archiveFileInfo.Index, mem);
    
                            string shortFileName = Path.GetFileName(archiveFileInfo.FileName);
                            byte[] content = mem.ToArray();
                            //...
                        }
                    }
                }
            }
        }
    }
