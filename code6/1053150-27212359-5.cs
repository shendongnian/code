	try
	{
		var request = WebRequest.Create("http://www.google.com");
		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		{
			WebHeaderCollection headers = response.Headers;
			using (Stream answer = response.GetResponseStream())
			{
				// Do stuff
			}
		}
	}
	catch (WebException e) when (e.Status == WebExceptionStatus.Timeout)
	{
		// If we got here, it was a timeout exception.
	}
	
