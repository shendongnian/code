		var response = await Client.GetAsync(apiUrl);
		using (var stream = await response.Content.ReadAsStreamAsync())
		using (var reader = new StreamReader(stream))
		using (var json = new JsonTextReader(reader))
		{
			if (json == null)
				return default(T);
	
			return _serializer.Deserialize<T>(json);
		}
	}
        
