    byte[] message = new byte[512];
    int bytesRead;
    bytesRead = stream.Read(message, 0, message.Length);
    ASCIIEncoding encoder = new ASCIIEncoding();
    Console.WriteLine(encoder.GetString(message, 0, bytesRead));
