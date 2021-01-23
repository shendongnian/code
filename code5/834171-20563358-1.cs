        var myObject = new MyObject { MyDictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } } };
        DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyObject), settings);
        var result = string.Empty;
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, myObject);
            result = Encoding.Default.GetString(ms.ToArray());
        }
