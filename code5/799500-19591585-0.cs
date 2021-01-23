        private void UploadFile(string fileToUpload)
        {
            Output = new Uri(Path.Combine(Output.ToString(), Path.GetFileName(fileToUpload)));
            FtpWebRequest request = WebRequest.Create(Output) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // in order to work with Microsoft Windows Server 2003 + IIS, we can't use passive mode.
            request.UsePassive = false;
            request.Credentials = new NetworkCredential(username, password);
            // Copy the contents of the file to the request stream.
            Stream dest = request.GetRequestStream();
            FileStream src = File.OpenRead(fileToUpload);
             
            int bufSize = (int)Math.Min(src.Length, 1024);
            byte[] buffer = new byte[bufSize];
            int bytesRead = 0;
            
            int numBuffersUploaded = 0;            
            do
            {
                bytesRead = src.Read(buffer, 0, bufSize);
                dest.Write(buffer, 0, bufSize);
                numBuffersUploaded++;
            }
            while (bytesRead != 0);
            dest.Close();
            src.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            if (response.StatusCode != FtpStatusCode.ClosingData)
            {
                Console.Error.WriteLine("Request {0}: Error uploading file to FTP server: {1} ({2})", Id, response.StatusDescription, response.StatusCode);
            }
            else
            {
                Console.Out.WriteLine("Request {0}: Successfully transferred file to {1}", Id, Output.ToString());
            }
        }
