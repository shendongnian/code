    using (var memoryStream = new MemoryStream())
    {
       var binaryFormatter = new BinaryFormatter();
       binaryFormatter.Serialize(memoryStream, <Your Original List Object>);
       memoryStream.Position = 0;
    
       <You actual List Object> =  binaryFormatter.Deserialize(memoryStream);
    }
