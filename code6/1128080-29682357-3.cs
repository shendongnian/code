    var input = new SerializeTest(4, 8);
    using (var ms = new MemoryStream())
    {
        var serializer = new XmlSerializer(typeof(SerializeTest));
        serializer.Serialize(ms, input);
        ms.Position = 0;
    
        var output = serializer.Deserialize(ms) as SerializeTest;
    }
