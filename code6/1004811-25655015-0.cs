    public static void Encode()
    {
      var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\dataOut.xml";
      using (var stream = new FileStream(path, FileMode.OpenOrCreate))
      {
        var serializer = new DataContractSerializer(typeof(Config), "Config", "http://TestNameSpace");
    
        serializer.WriteObject(stream, new Config(){SerializableDictionary = new SerializableDictionary<int, string> { { 1, "hello" }, { 2, "world"} }});
      }
    }
