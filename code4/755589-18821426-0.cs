    public void DownloadFile(stringHostURL, string UserName, string Password, stringSourceDirectory, string FileName, string LocalDirectory)
            {
                if(!File.Exists(LocalDirectory + FileName))
                {
                    try
                    {
                        FtpWebRequestrequestFileDownload = (FtpWebRequest)WebRequest.Create(HostURL + “/” + SourceDirectory + “/” + FileName);
                        requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                        requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                        FtpWebResponseresponseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                        StreamresponseStream = responseFileDownload.GetResponseStream();
                        FileStreamwriteStream = new FileStream(LocalDirectory + FileName, FileMode.Create);
                        intLength = 2048;
                        Byte[] buffer = new Byte[Length];
                        intbytesRead = responseStream.Read(buffer, 0, Length);
                        while(bytesRead > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, Length);
                        }
                        responseStream.Close();
                        writeStream.Close();
                        requestFileDownload = null;
                        responseFileDownload = null;
                    }
                    catch(Exception ex)
                    {
                        throwex;
                    }
                }
            }
