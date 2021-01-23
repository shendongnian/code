            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(Username, Password);
            try
            {
                //You have to call this or you would be unable to get a stream :)
                WebResponse response = fwr.GetResponse();
            }
            catch (Exception e)
            {
                throw e;
            }
            FileStream fs = new FileStream(localfile), FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, Convert.ToInt32(fs.Length));
            fs.Flush();
            fs.Close();
            //Now you are able to open a Stream
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            request.Abort();
