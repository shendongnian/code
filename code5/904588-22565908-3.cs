    var webClient = new WebClient();
    				
    using (var upstream = webClient.OpenWrite(url, "POST"))
    {
    	using (var writer = new StreamWriter(upstream))
    	{
    		writer.Write("{ \"test\" : \"json\" }");
    	}
    }
