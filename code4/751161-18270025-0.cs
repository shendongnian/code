    Stream stream = ...;
    using (var streamWriter = new StreamWriter(stream))
    using (var writer = new JsonTextWriter(streamWriter))
    {
        writer.Formatting = Formatting.Indented;
        writer.WriteStartArray();
        {
            writer.WriteStartObject();
            {
                writer.WritePropertyName("foo");
                writer.WriteValue(1);
                writer.WritePropertyName("bar");
                writer.WriteValue(2.3);
            }
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
    }
