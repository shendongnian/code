    /// <summary>
    /// Serialize object into Json string.
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="obj">Object which need to convert.</param>
    /// <returns>Json string</returns>
    public string SerializeAsJsonString<T>(T obj)
    {
        var jsonSerializer = new DataContractJsonSerializer(typeof(T));
        string jsonString = string.Empty;
        using (var memStream = new System.IO.MemoryStream())
        {
            jsonSerializer.WriteObject(memStream, obj);
            byte[] jsonArray = memStream.ToArray();
            jsonString = System.Text.Encoding.UTF8.GetString(jsonArray, 0, jsonArray.Length);
        }
        return jsonString;
    }
    /// <summary>
    /// Serialize Json string into object
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    /// <param name="jsonString">Json string which need to parse into object</param>
    /// <returns>Object of type T</returns>
    public T DeserializeJsonString<T>(string jsonString)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonString);
        using (var memStream = new System.IO.MemoryStream(data))
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(memStream);
        }
    }
