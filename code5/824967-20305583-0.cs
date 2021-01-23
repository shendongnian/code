            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(@"ftp://sss-xxx-red-001.ftp.azurewebsites.windows.net/site/wwwroot/test.png");
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpWebRequest.Timeout = -1;
            ftpWebRequest.ReadWriteTimeout = -1;
            ftpWebRequest.UsePassive = true;
            ftpWebRequest.Credentials = new NetworkCredential(@"myuser\$myuser", "myuser_password");
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;
            try
            {
                using (Stream requestStream = ftpWebRequest.GetRequestStream())
                {
                    byte[] fileContents = System.IO.File.ReadAllBytes(@"C:\_debug\test.png");
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();
                }
            }
            catch (Exception ex)
            {
                int i = 1;
            }
