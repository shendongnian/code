	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		writer.WriteStartObject();
		Type vType = value.GetType();
		MemberInfo[] properties = vType.GetProperties();
		foreach (PropertyInfo property in properties)
		{
			object serValue = null;
			if (property.Name == "Field4")
			{
				serValue = Convert.ToInt32(property.GetValue(value, null));
			}
			else
			{
				serValue = property.GetValue(value, null);
			}
			writer.WritePropertyName(property.Name);
			serializer.Serialize(writer, serValue);
		}
		writer.WriteEndObject();
	}
