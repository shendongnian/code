    private void Delete(string remoteFile) {
      string deleteRequest = ftpServer + remoteFile;
      FtpWebRequest request = (FtpWebRequest)WebRequest.Create(deleteRequest);
      request.Method = WebRequestMethods.Ftp.DeleteFile;
      request.Credentials = new NetworkCredential(ftpLoginName, ftpLoginPassword);
      request.Proxy = null;
      request.UseBinary = false;
      request.UsePassive = true;
      request.KeepAlive = false;
      FtpWebResponse response = (FtpWebResponse)request.GetResponse();
      Stream responseStream = response.GetResponseStream();
      StreamReader sr = new StreamReader(responseStream);
      sr.ReadToEnd();
      string StatusCode = response.StatusDescription;
      sr.Close();
      response.Close();
    }
