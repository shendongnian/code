    public static void CompressFiles(List<string> pathnames, string zipPathname)
    {
        try
        {
            using (FileStream stream = new FileStream(zipPathname,
                FileMode.Create, FileAccess.Write, FileShare.None))
            using (ZipOutputStream stream2 = new ZipOutputStream(stream))
            {
                foreach (string str in pathnames)
                {
                    using (FileStream stream3 = new FileStream(str,
                        FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(str));
                        stream2.PutNextEntry(entry);
                        stream3.CopyTo(stream2);
                    }
                }
                stream2.Finish();
            }
        }
        catch (Exception)
        {
            File.Delete(zipPathname);
            throw;
        }
    }
        
