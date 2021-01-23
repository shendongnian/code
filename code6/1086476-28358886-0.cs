    var obj = new { key = "value" };
    StringBuilder sb = new StringBuilder();
    using (StringWriter sw = new StringWriter(sb))
    using (JsonTextWriter writer = new JsonTextWriter(sw))
    {
        writer.QuoteChar = '\'';
        JsonSerializer ser = new JsonSerializer();
        ser.Serialize(writer, obj);
    }
    Console.WriteLine(sb.ToString());
