    byte[] message = new byte[256]; //This can now be 256 as that is the most messageLength can be.
    while (true)
    {
        //get the length of the message
        int messageLength = clientStream.ReadByte();
        if(messageLength == -1)
            break;
        // "Read(" can read less than the total length you requested, so you must loop till you have the entire message.
        int offset = 0;
        while(offset < messageLength)
        {
            offset += clientStream.Read(message, offset, messageLength - offest);
        }
        Console.WriteLine("client connected : " + Encoding.UTF8.GetString(message, 0, message.Length));
    }
