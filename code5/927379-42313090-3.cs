	static async Task<T> GetDataObjectFromAPI<T>(string apiUrl)
	{
        using (var stream = await _client.GetStreamAsync(apiUrl).ConfigureAwait(false))
		using (var reader = new StreamReader(stream))
		using (var json = new JsonTextReader(reader))
		{
			if (json == null)
				return default(T);
	
			return _serializer.Deserialize<T>(json);
		}
	}
        
