    private void ZipSafe(string p_FolderName, string p_ArchiveName)
    {
    Task.Factory.StartNew(() =>
    {
    try
    {
        if (File.Exists(p_ArchiveName))
            File.Delete(p_ArchiveName);
    
        string[] l_DataSet = Directory.GetFiles(p_FolderName, "*.txt");
        using (ZipArchive l_Zip = ZipFile.Open(p_ArchiveName, ZipArchiveMode.Create))
        {
            foreach (string l_File in l_DataSet)
            {
    
                using (FileStream l_Stream = new FileStream(l_File, FileMode.Open, FileAccess.Read, FileShare.Delete | FileShare.ReadWrite))
                {
                    ZipArchiveEntry l_ZipArchiveEntry = l_Zip.CreateEntry(Path.GetFileName(l_File), CompressionLevel.Optimal);
                    using (Stream l_Destination = l_ZipArchiveEntry.Open())
                    {
                        l_Stream.CopyTo(l_Destination);
                    }
                }
            }
            l_Zip.Dispose();
        }
    }
    catch (System.Exception e)
    {
        using (StreamWriter sw = new StreamWriter(@"C:\Users\**\Documents\ErrorZip.txt"))
        {
            string l = e.ToString();
            sw.WriteLine(l);
            sw.Close();
        }
    }
    }
    }
