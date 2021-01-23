	public static List<T> DeserializeSingleOrList<T>(JsonReader jsonReader)
	{
		if (jsonReader.Read())
		{
			switch (jsonReader.TokenType)
			{
				case JsonToken.StartArray:
					return new JsonSerializer().Deserialize<List<T>>(jsonReader);
				case JsonToken.StartObject:
					var instance = new JsonSerializer().Deserialize<T>(jsonReader);
					return new List<T> { instance };
			}
		}
		throw new InvalidOperationException("Unexpected JSON input");
	}
