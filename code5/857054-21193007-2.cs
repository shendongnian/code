	private JArray GetRESTData(string uri)
	{
		var json = ReadFromUri(uri);
		
		return JsonConvert.DeserializeObject<JArray>(json);
	}
	
	private string ReadFromUri(string uri)
	{
		using (var webRequest = (HttpWebRequest)WebRequest.Create(uri))
		using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
		using (var reader = new StreamReader(webResponse.GetResponseStream()))
		{
			return reader.ReadToEnd();
		}	
	}
