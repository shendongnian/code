	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		Type valueType = value.GetType();
		if (valueType.IsArray)
		{
			var jArray = new JArray();
			foreach (var item in (IEnumerable)value)
				jArray.Add(JToken.FromObject(item, serializer));
			jArray.WriteTo(writer);
		}
		else
		{
            JProperty typeHintProperty = TypeHintPropertyForType(value.GetType());
			var jObj = new JObject();
            if (typeHintProperty != null)
                jo.Add(typeHintProperty);
			foreach (PropertyInfo property in valueType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				if (property.CanRead)
				{
					object propertyValue = property.GetValue(value);
					if (propertyValue != null)
						jObj.Add(property.Name, JToken.FromObject(propertyValue, serializer));
				}
			}
			jObj.WriteTo(writer);
		}
	}
