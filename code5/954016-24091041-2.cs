    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb); 
    using(JsonWriter writer = new JsonTextWriter(sw))
    {
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("CPU");
        writer.WriteValue("Intel");
        writer.WritePropertyName("PSU");
        writer.WriteValue("500W");
        writer.WritePropertyName("Drives");
        writer.WriteStartArray();
        writer.WriteValue("DVD read/writer");
        writer.WriteComment("(broken)");
        writer.WriteValue("500 gigabyte hard drive");
        writer.WriteValue("200 gigabype hard drive");
        writer.WriteEnd();
        writer.WriteEndObject();
    }
