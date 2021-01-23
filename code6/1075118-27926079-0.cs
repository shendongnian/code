    private static void UploadFileToFtp(string sourceFile, string destFile)
            {
                try
                {
                    var ServerReportFTP = ConfigurationManager.AppSettings["ServerReportFTP"];
                    var ServerReportFTPUserName = ConfigurationManager.AppSettings["ServerReportFTPUserName"];
                    var ServerReportFTPPassword = ConfigurationManager.AppSettings["ServerReportFTPPassword"];
    
                    var request = (FtpWebRequest)WebRequest.Create(ServerReportFTP);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(ServerReportFTPUserName, ServerReportFTPPassword);
    
                    var sourceStream = new StreamReader(sourceFile);
                    var fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                    sourceStream.Close();
                    request.ContentLength = fileContents.Length;
    
                    var requestStream = request.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
    
                    //var response = (FtpWebResponse)request.GetResponse();
                    //response.Close();
                }
                catch { }
            }
