    public async Task<ActionResult> CreateWordFile()
    {
    	string body = "--A300x\r\n"
    			+ "Content-Disposition: form-data; name=\"file\"; filename=\"csm.docx\"\r\n"
    			+ "Content-Type: application/octet-stream\r\n"
    			+ "\r\n"
    			+ "This is some content\r\n"
    			+ "\r\n"
    			+ "--A300x--\r\n";
    
    	byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(body);
    	Stream stream = new MemoryStream(fileBytes);
    
    	LiveLoginResult loginStatus = await authClient.InitializeWebSessionAsync(HttpContext);
    	if (loginStatus.Status == LiveConnectSessionStatus.Connected)
    	{
    		connectedClient = new LiveConnectClient(this.authClient.Session);
    		string url = "https://apis.live.net/v5.0/me/skydrive/files?access_token=" + this.authClient.Session.AccessToken;
    
    
    		HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
    		httpWebRequest2.ContentType = "multipart/form-data; boundary=A300x";
    		httpWebRequest2.Method = "POST";
    		httpWebRequest2.KeepAlive = true;
    		httpWebRequest2.Credentials = System.Net.CredentialCache.DefaultCredentials;
    		httpWebRequest2.ContentLength = fileBytes.Length;
    		Stream stream2 = httpWebRequest2.GetRequestStream();
    		stream2.Write(fileBytes, 0, fileBytes.Length);
    		WebResponse webResponse2 = httpWebRequest2.GetResponse();
    		}
    
    	return View();
    }
