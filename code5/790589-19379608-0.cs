	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
		var converters = serializer.Converters.Where(x => !(x is TypeInfoConverter)).ToArray();
		var jObject = JObject.FromObject(value);
		jObject.AddFirst(new JProperty("Type", value.GetType().Name));
		writer.WriteStartObject();
		foreach (var property in jObject.Properties()) {
			property.WriteTo(writer, converters);
		}
		writer.WriteEndObject();
	}
