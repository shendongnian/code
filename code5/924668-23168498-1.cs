    try
        {
            FtpWebResponse response = (FtpWebResponse)req.GetResponse();
            Stream stream = response.GetResponseStream();
            byte[] buffer = new byte[2048];
            var sw = new StreamWriter( new FileStream(DownloadedFilePath, FileMode.Create),
        Encoding.UTF8);
            int ReadCount = stream.Read(buffer, 0, buffer.Length);
            while (ReadCount > 0)
            {
               sw.Write(buffer, 0, ReadCount);
              ReadCount = stream.Read(buffer, 0, buffer.Length);
            }
            ResponseDescription = response.StatusDescription;
            sw.Close();
            stream.Close();
        }
    
    
  
