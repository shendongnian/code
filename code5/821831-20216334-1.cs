	try
	{
		string content = webClient.DownloadString(url);
	}
	catch (WebException e)
	{
		HttpWebResponse response = (System.Net.HttpWebResponse)we.Response;
		
		var errorStatus = response.StatusCode;
	}
