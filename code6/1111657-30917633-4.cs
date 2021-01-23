    public class PropertyInfoConverter : JsonConverter
    {
	public override bool CanWrite
	{
		get
		{
			return false;
		}
	}
	public override bool CanConvert(Type objectType)
	{
		return typeof(PropertyInfo).IsAssignableFrom(objectType);
	}
	
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		string propertyName = null;
		string assemblyName = null;
		string typeName = null;
	
		while (reader.Read())
		{
			if (reader.TokenType == JsonToken.PropertyName)
			{
				string value = reader.Value.ToString();
				
				switch (reader.Value.ToString())
				{
					case "Name":
						if (reader.Read())
						{
							propertyName = reader.Value.ToString();
						}
						break;
					case "AssemblyName":
						if (reader.Read())
						{
							assemblyName = reader.Value.ToString();
						}
						break;
					case "ClassName":
						if (reader.Read())
						{
							typeName = reader.Value.ToString();
						}
						break;
				}
			}		
		}
		
		return Type.GetType(typeName + ", " + assemblyName).GetProperty(propertyName);
	}
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		// When the property "CanWrite" returns false this method is never expected to be called.
		throw new NotImplementedException();
	}
