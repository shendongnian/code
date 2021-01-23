	try
	{
		// API base address
		var baseUrl = @"http://api.arbetsformedlingen.se/";
		// method platsannons/soklista/komunner with parameter landid set to some value
		var method = string.Format("platsannons/soklista/kommuner?lanid={0}", 10);
		var client = new WebClient();
		// important - the service requires this two parameters!
		client.Headers.Add(HttpRequestHeader.Accept, "application/xml");
		client.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US");
		// retrieve content
		var responseContent = client.DownloadString(string.Format("{0}{1}", baseUrl, method));
		// "create" the xml object
		var xml = XDocument.Parse(responseContent);
		// do something with the xml
		xml.Root.Descendants("sokdata").ToList().ForEach(li =>
		{
			Console.WriteLine(string.Format("{0} - {1}", li.Element("id").Value, li.Element("namn").Value));
		});
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
		exception.Dump();
	}
