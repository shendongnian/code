		string testCase = "http://test/mediacenter/Photo Gallery/Conf 1/1.jpg";
		string urlBase = "http://test/mediacenter/Photo Gallery/";
		
		if(!testCase.StartsWith(urlBase))
		{
			throw new Exception("URL supplied doesn't belong to base URL.");
		}
		
		Uri uriTestCase = new Uri(testCase);
		Uri uriBase = new Uri(urlBase);
		
		if(uriTestCase.Segments.Length > uriBase.Segments.Length)
		{
			System.Console.Out.WriteLine(uriTestCase.Segments[uriBase.Segments.Length]);
		}
		else
		{
			Console.Out.WriteLine("No child segment...");
		}
