        private void ftplogdump()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUploadloc);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            StreamReader sourceStream = new StreamReader(currentLog);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            // Remove before publishing
            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
        }
