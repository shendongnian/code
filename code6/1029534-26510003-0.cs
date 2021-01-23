    //On the client:
    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    NetworkStream stream = client.GetStream();
    
    // Send the message to the connected TcpServer.
    stream.Write(data, 0, data.Length);
    
    //On the server:
    i = stream.Read(bytes, 0, bytes.Length);
    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
    //Now you can parse this data to the types that you need.
