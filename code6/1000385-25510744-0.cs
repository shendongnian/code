    void Main()
    {
        CopyToZip(@"D:\temp\temp.accdb", @"D:\temp\temp.zip");
    }
    private static void CopyToZip(string source, string dest)
    {
         using (ZipFile zip = new ZipFile(dest))
         {
             ZipEntry e = zip.UpdateFile(source, string.Empty);
             e.Comment = "Database archived in date: " + DateTime.Today.ToShortDateString();
             zip.Save();
         }
    }
