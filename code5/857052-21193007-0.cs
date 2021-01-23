	private JArray GetRESTData(string uri)
	{
		var webRequest = (HttpWebRequest)WebRequest.Create(uri);
		var webResponse = (HttpWebResponse)webRequest.GetResponse();
		
		var reader = new StreamReader(webResponse.GetResponseStream());
		string s = reader.ReadToEnd();
		
		return JsonConvert.DeserializeObject<JArray>(s);
	}
