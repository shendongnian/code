	// We will store the response of the request here
	string siteContent = string.Empty;
	
	// The url you want to grab
	string url = "http://google.com";
	
	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
	request.AutomaticDecompression = DecompressionMethods.GZip;
	
	using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
	using(Stream responseStream = response.GetResponseStream())
	using(StreamReader streamReader = new StreamReader(responseStream))
	{
		siteContent = streamReader.ReadToEnd();
	}
	
	Console.WriteLine (siteContent);
