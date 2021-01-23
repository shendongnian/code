    private string jsonText = "{\"Id\": 1, \"Name\": \"kanozuki\", \"Number\":\"0100\"}";
    TestObject obj = Deserialise<TestObject>(jsonText);
    public T Deserialise<T>(string json)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                T result = (T)deserializer.ReadObject(stream);
                return result;
            }
        }
