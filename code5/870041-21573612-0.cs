    var bytes = new byte[50]; // example byte array
    
    using(var stream = new MemoryStream(bytes))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var obj = (YourExpectedType)formatter.Deserialize(stream);
    }
