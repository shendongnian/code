    	private class DictionaryConverter : JsonConverter
		{
			public override bool CanWrite { get { return false; } }
			public override bool CanConvert(Type objectType)
			{
				return objectType == typeof(Dictionary<string, string>);
			}
			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				if (reader.TokenType == JsonToken.StartArray)
				{
					reader.Read();
					if (reader.TokenType == JsonToken.EndArray)
						return new Dictionary<string, string>();
					else
						throw new JsonSerializationException("Non-empty JSON array does not make a valid Dictionary!");
				}
				else if (reader.TokenType == JsonToken.Null)
				{
					return null;
				}
				else if (reader.TokenType == JsonToken.StartObject)
				{
					Dictionary<string, string> ret = new Dictionary<string, string>();
					reader.Read();
					while (reader.TokenType != JsonToken.EndObject)
					{
						if (reader.TokenType != JsonToken.PropertyName)
							throw new JsonSerializationException("Unexpected token!");
						string key = (string)reader.Value;
						reader.Read();
						if (reader.TokenType != JsonToken.String)
							throw new JsonSerializationException("Unexpected token!");
						string value = (string)reader.Value;
						ret.Add(key, value);
						reader.Read();
					}
					return ret;
				}
				else
				{
					throw new JsonSerializationException("Unexpected token!");
				}
			}
			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				throw new NotImplementedException();
			}
		}
