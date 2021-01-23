        private static void UploadFileToFTP(string source)
        {
            String sourcefilepath = "C:\\Users\\Desktop\\LUVS\\a.xml";  
            String ftpurl = "100.100.0.35"; // e.g. fake IDs
            String ftpusername = "ftp"; // e.g. fake username
            String ftppassword = "1now"; // e.g. fake password
            try
            {
                string filename = Path.GetFileName(sourcefilepath);
                string ftpfullpath = "ftp://" + ftpurl + "/" + filename ;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;
                FileStream fs = File.OpenRead(sourcefilepath); // here, use sourcefilepath insted of source.
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
