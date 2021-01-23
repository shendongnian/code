    // Client
    using(var ms = new MemoryStream())
    {
       using (var writer = new BinaryWriter(ms))
       {
           //writes 8 bytes
           writer.Write(myDouble);
           
           //writes 4 bytes
           writer.Write(myInteger);
           
           //writes 4 bytes
           writer.Write(myOtherInteger);
       }    
       //The memory stream will now have all the bytes (16) you need to send to the server
    }
    
    // Server
    using (var reader = new BinaryReader(yourStreamThatHasTheBytes))
    {
        //Make sure you read in the same order it was written....
        //reads 8 bytes
        var myDouble = reader.ReadDouble();
        
        //reads 4 bytes
        var myInteger = reader.ReadInt32();
 
        //reads 4 bytes
        var myOtherInteger = reader.ReadInt32();
    }
