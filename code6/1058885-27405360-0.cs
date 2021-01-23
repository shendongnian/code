	var lines = Arguments.AsParallel().Select(Argument =>
	{
		if (Argument != Command_Name)
		{
			WebRequest web_request = WebRequest.Create("https://www.aol.com/?command=1&domain=" + Argument);
			web_request.Timeout = 5000;
			((HttpWebRequest)web_request).UserAgent = "Mozilla Firefox 5.0";
			HttpWebResponse web_response = (HttpWebResponse)web_request.GetResponse();
			StreamReader response = new StreamReader(web_response.GetResponseStream(), Encoding.UTF8);
			return Argument + " => " + response.ReadToEnd();
		}
	}).ToArray();
	
	var concate = string.Join(Environment.NewLine, lines);
