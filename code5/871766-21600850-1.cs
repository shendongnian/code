      String url = @"http://www.example.com/";
      Byte[] dat = null;
    
      // In case you need credentials for Proxy
      if (Object.ReferenceEquals(null, WebRequest.DefaultWebProxy.Credentials))
        WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
    
      using (WebClient wc = new WebClient()) {
        // Seems that you need raw data, Byte[]; if you want String - wc.DownLoadString(url);
        dat = wc.DownloadData(url);
      }
