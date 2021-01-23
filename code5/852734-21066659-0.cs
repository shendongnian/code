	public void AccessToken(string code)
	{
		string url = @"https://api.freeagent.com/v2/token_endpoint";
		WebClient client = new WebClient();
		string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKey + ":" + ApiSecret));
		client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
		client.Headers[HttpRequestHeader.Accept] = "application/json";
		client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
		client.Headers[HttpRequestHeader.UserAgent] = "Java/1.6.0_33";
		client.Headers[HttpRequestHeader.Host] = "api.freeagent.com";
		client.Headers[HttpRequestHeader.Connection] = "close";
		client.Headers["grant_type"] = "authorization_code";
		string data = string.Format(
			"grant_type=authorization_code&code={0}&redirect_uri=http%3A%2F%2Flocalhost%3A8080",
			code);
		var result = client.UploadString(url, data);
	}
