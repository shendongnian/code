        private FtpWebRequest GetRequest(string requestUri, string method, bool keepAlive)
        {
            FtpWebRequest retVal = null;
            try
            {
                retVal = FtpWebRequest.Create(requestUri) as FtpWebRequest;
                retVal.Method = method;
                retVal.Credentials = new NetworkCredential(username, password);
                retVal.UsePassive = true;
                retVal.UseBinary = true;
                retVal.KeepAlive = keepAlive;
               // retVal = request.GetRequestStream();
                
            }
            catch (Exception ex)
            {
            }
            return retVal;
        }
        public bool UploadFile(string fileToUpload)
        {
            bool retVal = false;
            
            FtpWebRequest request = null;
            Stream outstream = null;
            FileStream fs = null;
            try
            {
                request = GetRequest(String.Format("{0}/{1}", host, Path.GetFileName(fileToUpload)), WebRequestMethods.Ftp.UploadFile, false);
                
                byte[] buffer = new byte[4096];
                int count = 0;
                outstream = request.GetRequestStream();
                using (FileStream streamReader = File.OpenRead(fileToUpload))
                {
                    int read;
                    while ((read = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Console.WriteLine("Writing to FTP stream: " + (count += read));
                        outstream.Write(buffer, 0, read);
                        outstream.Flush();
                    }
                }
      
                retVal = true;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Console.WriteLine("Closing the FTP stream");
                if (request != null)
                {
                    request.Abort();
                }
                if (outstream != null)
                    outstream.Close();
            }
            return retVal;
        }
