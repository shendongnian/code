        class SecureWebClient : WebClient
     	{
    		protected override WebRequest GetWebRequest(Uri address)
	       	{
    			HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
    			string certPath = @"C:\TEMP\ClientCertificateFile.cer";
    			X509Certificate myCert = X509Certificate.CreateFromCertFile(certPath);
    			request.ClientCertificates.Add(myCert);
    			return request;
    		}
    	}
