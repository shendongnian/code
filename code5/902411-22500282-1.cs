<!-- -->
    var json = @"{
        ""ratings_total"": {
            ""1"": ""1"",
            ""2"": 0,
            ""3"": 0,
            ""4"": 0,
            ""5"": ""3""
        }
    }";
    // Convert string to a stream (only nessesary for this example)
    var stream = new MemoryStream();
    var writer = new StreamWriter(stream);
    writer.Write(json);
    writer.Flush();
    stream.Position = 0;
    
    // Settings to enable dictionary serialization
    var settings = new DataContractJsonSerializerSettings();
    settings.UseSimpleDictionaryFormat = true;
    var ser = new DataContractJsonSerializer(typeof(Foo), settings);
    
    // Deserialize object
    var obj = (Foo)ser.ReadObject(stream);
