    // taken from example linked in comment
    public long download(string remoteFile, string localFile)
    {
        long totalBytes = 0;
        try
        {
            // ...blah
            try
            {
                while (bytesRead > 0)
                {
                    localFileStream.Write(byteBuffer, 0, bytesRead);
                    totalBytes += bytesRead;
                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                }
            }
            // ...blah
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        return totalBytes;
    }
