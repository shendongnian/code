    try
    {
        if (File.Exists(path))
             File.Delete(path);
        using(Stream stream = service.DownloadContent(fileID))
        {
            using (FileStream fileStream = File.OpenWrite(fileName))
            {
                // Write the stream to the file on disk.
                var buf = new byte[1024];
                int numBytes;
                while ((numBytes = stream.Read(buf, 0, buf.Length)) > 0)
                {
                    fileStream.Write(buf, 0, numBytes);
                }
            }
        }
    }
    catch (IOException e)
    {
        MessageBox.Show("The refresh failed, try again in a few seconds."); 
    }
