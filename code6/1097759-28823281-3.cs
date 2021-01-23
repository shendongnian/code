    string html = string.Empty;
	string uri = "http://google.com";
	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
	request.Timeout = TimeSpan.FromMinutes(5);
	
	using (HttpWebResponse response = (HttpWebResonse)request.GetResponse())
	using (Stream stream = response.GetResponseStream())
	using (StreamReader reader = new StreamReader(stream))
	{
		html = reader.ReadToEnd();
	}
	
	
