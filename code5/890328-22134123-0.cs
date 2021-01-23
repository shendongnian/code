    class Program
    {
        static object lockObj = new object();
        
        static void Main(string[] args)
        {
            string zipPath = @"C:\Temp\Test\Test.zip";
            string extractPath = @"c:\Temp\xxx";
            string directory = "testabc";
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                var result = from currEntry in archive.Entries
                             where Path.GetDirectoryName(currEntry.FullName) == directory
                             where !String.IsNullOrEmpty(currEntry.Name)
                             select currEntry;
                             
                             
                foreach (ZipArchiveEntry entry in result)
                {
                    entry.ExtractToFile(Path.Combine(extractPath, entry.Name));
                }
            } 
        }        
    }
