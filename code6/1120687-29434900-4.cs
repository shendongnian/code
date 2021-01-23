	public T GetObjectFromApi<T>(string url)
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		try
		{
			WebResponse response = request.GetResponse();
			using (Stream responseStream = response.GetResponseStream())
			{
				StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
				var jsonReader = new JsonTextReader(reader);
				var serializer = new JsonSerializer();
				return serializer.Deserialize<T>(jsonReader);
			}
		}
		catch (WebException)
		{		
			return null;
		}
	}
