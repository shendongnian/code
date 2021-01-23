    class DtoConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return (objectType.IsClass && 
    				objectType.GetInterfaces().Any(i => i == typeof(IHasFieldStatus)));
    	}
    	
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var jsonObj = JObject.Load(reader);
    		var targetObj = (IHasFieldStatus)Activator.CreateInstance(objectType);
    		
    		var dict = new Dictionary<string, FieldDeserializationStatus>();
    		targetObj.FieldStatus = dict;
    		
    		foreach (PropertyInfo prop in objectType.GetProperties())
    		{
    			if (prop.CanWrite && prop.Name != "FieldStatus")
    			{
    				JToken value;
    				if (jsonObj.TryGetValue(prop.Name, StringComparison.OrdinalIgnoreCase, out value))
    				{
    					if (value.Type == JTokenType.Null)
    					{
    						dict.Add(prop.Name, FieldDeserializationStatus.WasSetToNull);
    					}
    					else
    					{
    						prop.SetValue(targetObj, value.ToObject(prop.PropertyType, serializer));
    						dict.Add(prop.Name, FieldDeserializationStatus.HasValue);
    					}
    				}
    				else
    				{
    					dict.Add(prop.Name, FieldDeserializationStatus.WasNotPresent);
    				}
    			}
    		}
    		
    		return targetObj;
    	}
    	
    	public override bool CanWrite
    	{
    		get { return false; }
    	}
    	
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
