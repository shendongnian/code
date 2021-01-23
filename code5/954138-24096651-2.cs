        var stringBuilder = new StringBuilder();
        var stringWriter = new StringWriter(stringBuilder);
        string jsonString = null;
        using (var jsonWriter = new JsonTextWriter(stringWriter))
        {
           writer.Formatting = Formatting.Indented;
           writer.WriteStartObject();
           writer.WriterPropertyName("username");
           writer.WritePropertyValue("user");
           writer.WriterPropertyName("password");
           writer.WritePropertyValue("pass");
           writer.WriteEnd();
           writer.WriteEndObject();
           jsonString = writer.ToString();
        }
