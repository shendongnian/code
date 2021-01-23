    public class FTPLister
        {
            private List<Entity> fileList = new List<Entity>();
    
            public List<Entity> ListFilesOnFTP(string ftpAddress, string user, string password)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
    
                request.Credentials = new NetworkCredential(user, password);
    
                List<string> tmpFileList = new List<string>();
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
    
                    while (!reader.EndOfStream)
                    {
                        tmpFileList.Add(reader.ReadLine());
                    }
                }
    
                Uri ftp = new Uri(ftpAddress);
                foreach (var f in tmpFileList)
                {
                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(new Uri(ftp, f));
                    req.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                    req.Credentials = new NetworkCredential(user, password);
    
                    using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse())
                    {
                        fileList.Add(new Entity() { fileName=f, uploadDate=resp.LastModified });
                    }
                }
    
                fileList = fileList.Where(p => p.uploadDate>=DateTime.Today && p.uploadDate<DateTime.Today.AddDays(1)).ToList();
                return fileList;
            }
        }
