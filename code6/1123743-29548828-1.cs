    var json = "{YOUR JSON}";
    
    // Option 1
    var d1 = JsonConvert.DeserializeObject<RootObject>(json);
    
    // Option 2
    using (var stringReader = new StringReader(json))
    {
        var d2 = (RootObject)new JsonSerializer().Deserialize(stringReader, typeof(RootObject));
    }
