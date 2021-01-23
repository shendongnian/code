    public static string ToJson<T>(this T obj) where T : class
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        using (var stream = new MemoryStream())
        {
            serializer.WriteObject(stream, obj);
            return Encoding.Default.GetString(stream.ToArray());
        }
    }
