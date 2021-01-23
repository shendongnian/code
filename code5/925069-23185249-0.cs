    public static string Serialise(YourObject data)
    {
	StringBuilder sb = new StringBuilder();
	StringWriter sw = new StringWriter(sb);
	using (JsonWriter writer = new JsonTextWriter(sw))
	{
		writer.WriteStartObject();
		writer.WritePropertyName("propertyName1");
		if (data.Property1 == null)
		{
			writer.WriteNull();
		}
		else
		{
			writer.WriteValue(data.Property1);
		}
		writer.WritePropertyName("propertyName2");
		writer.WriteStartArray();
		foreach (var something in data.CollectionProperty)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("p1");
			writer.WriteValue(something.prop1);
			writer.WritePropertyName("p2");
			writer.WriteValue(something.prop2);
			writer.WritePropertyName("p3");
			writer.WriteValue(something.prop3);
			writer.WriteEndObject();
		}
		writer.WriteEndArray();
		writer.WriteEndObject();
	}
	return sb.ToString();
    }
