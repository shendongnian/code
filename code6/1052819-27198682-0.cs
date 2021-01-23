        private void uploadFTP(DirectoryInfo d, string ftp)
        {
            FileInfo[] flist = d.GetFiles();
            if (flist.GetLength(0) > 0)
            {
                foreach (FileInfo txf in flist)
                {
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftp + txf.Name);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential("username", "password");
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.KeepAlive = false;
                    FileStream stream = File.OpenRead(txf.FullName);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Close();
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    txf.Delete();
                }
            }
        }
