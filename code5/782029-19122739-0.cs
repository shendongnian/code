        private static byte[] GetFile(string file, bool inBound)
    {
        string path;
        if (inBound)
            path = Config.settings["FTPIn"] + file;
        else
            path = Config.settings["FTPOut"] + file;
    
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        request.UseBinary = true;
    
        request.Credentials = new NetworkCredential(Config.Settings["FTPUser"], Config.Settings["FTPPass"]);
        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        byte[] file_contents = null;
    
        using (Stream responseStream = response.GetResponseStream())
        {
            byte[] buffer = new byte[2048];
            using (MemoryStream ms = new MemoryStream())
            {
                int readCount = responseStream.Read(buffer, 0, buffer.Length);
                while (readCount > 0)
                {
                    ms.Write(Buffer, 0, readCount);
                    readCount = responseStream.Read(buffer, 0, buffer.Length);
                }
                
                file_contents = ms.ToArray();
            }
        }
    
        return file_contents;
    }
