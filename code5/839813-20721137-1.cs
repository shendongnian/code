    private static object GetObject(JsonReader reader)
    {
    	switch (reader.TokenType)
    	{
    		case JsonToken.StartObject:
    		{
    			var dictionary = new Dictionary<string, object>();
    
    			while (reader.Read() && (reader.TokenType != JsonToken.EndObject))
    			{
    				if (reader.TokenType != JsonToken.PropertyName)
    					throw new InvalidOperationException("Unknown JObject conversion state");
    
    				string propertyName = (string) reader.Value;
    
    				reader.Read();
    				object propertyValue = GetObject(reader);
    						
    				object existingValue;
    				if (dictionary.TryGetValue(propertyName, out existingValue))
    				{
    					if (existingValue is List<object>)
    					{
    						var list = existingValue as List<object>;
    						list.Add(propertyValue);
    					}
    					else
    					{
    						var list = new List<object> {existingValue, propertyValue};
    						dictionary[propertyName] = list;
    					}
    				}
    				else
    				{
    					dictionary.Add(propertyName, propertyValue);
    				}
    			}
    
    			return dictionary;
    		}
    		case JsonToken.StartArray:
    		{
    			var list = new List<object>();
    
    			while (reader.Read() && (reader.TokenType != JsonToken.EndArray))
    			{
    				object propertyValue = GetObject(reader);
    				list.Add(propertyValue);
    			}
    
    			return list;
    		}
    		default:
    		{
    			return reader.Value;
    		}
    	}
    }
