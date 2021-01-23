    byte[] buffer;
    int offset = 0;
    int bytesRead = await Stream.ReadAsync(buffer, offset, buffer.Length - offset);
    int bytesRemaining = bytesRead;
    while (bytesRemaining != 0 && haveCompletishPacket(buffer, offset, bytesRemaining)) {
        using (var memoryStream = new MemoryStream(buffer, offset, bytesRead)) {
            int size = deserializer.Deserialize(memoryStream);
            // deserialize as much as possible, if you fail somewhere, 
            // just reinit the deserializer and return
    
            // if we got here we have a packet, produce it
            offset += memoryStream.Position;
            bytesRemaining -= memoryStream.Position;
        }
     }
        
