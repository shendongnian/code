                String imageURL = "xyz";
                String userName = "xyz";
                String password = "xyz";
                String destinationFolder = "xyz";
                Uri ftpSourceFilePath = new Uri(imageURL);
    
                if (ftpSourceFilePath.Scheme == Uri.UriSchemeHttp)
                {
                    HttpWebRequest objRequest = (HttpWebRequest)HttpWebRequest.Create(ftpSourceFilePath);
                    NetworkCredential objCredential = new NetworkCredential(userName, password);
                    objRequest.Credentials = objCredential;
                    objRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                    StreamReader objReader = new StreamReader(objResponse.GetResponseStream());
                    int len = 0;
                    int iProgressPercentage = 0;
                    FileStream objFS = new FileStream((destinationFolder), FileMode.Create, FileAccess.Write, FileShare.Read);
                    byte[] buffer = new byte[1024];
                    while ((len = objReader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
    
                        objFS.Write(buffer, 0, len);
                  
                    }
                }
