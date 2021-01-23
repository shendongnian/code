	static async Task<T> GetDataObjectFromAPI<T>(string apiUrl)
	{
		var response = await _client.GetAsync(apiUrl);
		using (var stream = await response.Content.ReadAsStreamAsync())
		using (var reader = new StreamReader(stream))
		using (var json = new JsonTextReader(reader))
		{
			if (json == null)
				return default(T);
	
			return _serializer.Deserialize<T>(json);
		}
	}
        
