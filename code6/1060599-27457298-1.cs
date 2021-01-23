    // Client
    using(var ms = new MemoryStream())
    {
       using (var writer = new BinaryWriter(ms))
       {
           writer.Write(myDouble);
           writer.Write(myInteger);
       }    
       // the memory stream will now have all the bytes you need to send to the server.
    }
    
    // Server
    using (var reader = new BinaryReader(yourStreamThatHasTheBytes))
    {
        //Make sure you read in the same order it was written....
        var myDouble = reader.ReadDouble();
        var myInteger = reader.ReadInt32();
    }
