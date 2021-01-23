    private string post(string content)
	{
		var result = String.Empty;
		var uri = new Uri(_url);
		WebRequest req = HttpWebRequest.Create(uri);
		req.Method = "POST";
		req.ContentType = "text/xml";
		String encoded = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("user:pass"));
		req.Headers.Add("Authorization", "Basic " + encoded);
		using (var s = req.GetRequestStream())
		using (var sw = new StreamWriter(s, Encoding.UTF8))
		{
			sw.Write(content);
		}
		using (var s = req.GetResponse().GetResponseStream())
		using (var sr = new StreamReader(s, Encoding.UTF8))
		{
			result = sr.ReadToEnd();
		};
		return result;
	}
