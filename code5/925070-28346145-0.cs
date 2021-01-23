    public static string ToJson(this Person p)
    {
        StringWriter sw = new StringWriter();
        JsonTextWriter writer = new JsonTextWriter(sw);
    
        // {
        writer.WriteStartObject();
    
        // "name" : "Jerry"
        writer.WritePropertyName("name");
        writer.WriteValue(p.Name);
    
        // "likes": ["Comedy", "Superman"]
        writer.WritePropertyName("likes");
        writer.WriteStartArray();
        foreach (string like in p.Likes)
        {
            writer.WriteValue(like);
        }
        writer.WriteEndArray();
    
        // }
        writer.WriteEndObject();
    
        return sw.ToString();
    }
