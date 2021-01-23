    public void upload(string remoteFile, string localFile)
    {
        FileStream localFileStream;
        FtpWebResponse ftpResponse;
        try
        {
            ftpRequest = (FtpWebRequest) FtpWebRequest.Create(host + "/" + remoteFile);
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpStream = ftpRequest.GetRequestStream();
            localFileStream = new FileStream(localFile, FileMode.Create);
            byte[] byteBuffer = new byte[bufferSize];
            int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
             
            while (bytesSent != 0)
            {
                ftpStream.Write(byteBuffer, 0, bytesSent);
                bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
            }
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            Console.WriteLine("Upload status: {0}, {1}", ftpResponse.StatusCode, ftpResponse.StatusDescription);
        }
        catch (Exception ex)
        {
            // log exception
            Console.WriteLine(ex.ToString());
            // throw;
        }
        finally
        {
            if (localFileStream != null)
            {
                localFileStream.Close();
            }
            if (ftpStream != null)
            {
                ftpStream.Close();
            }   
            if (ftpResponse != null)
            {
                ftpResponse.Close();
            }            
            ftpRequest = null;
        }
    } 
