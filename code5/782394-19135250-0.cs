	public HttpStatusCode GetRedirectStatusCode(string destinationUrl)
	{
		var request = (HttpWebRequest)WebRequest.Create(link);
		request.Method = "HEAD";
		request.KeepAlive = false;
		request.ProtocolVersion = HttpVersion.Version10;
		request.Timeout = 180000;
		
		using(var response = (HttpWebResponse)request.GetResponse())
		{
			return response.StatusCode;
		}
	}
