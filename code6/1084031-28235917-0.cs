    public static void CompressFiles(List<string> pathnames, string zipPathname)
    {
        const int BufferSize = 4096;
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
                        byte[] buffer = new byte[BufferSize];
                        int read;
                        while ((read = stream3.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream2.Write(buffer, 0, read);
                        }
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
