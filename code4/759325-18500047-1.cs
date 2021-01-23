    var bytes = _udpClient.Receive(ref remoteEP);
    var packetString = new ASCIIEncoding().GetString(bytes);
    var reader = new StringReader(packetString);
    reader.ReadLine();  // Stuff!
    reader.ReadLine();  // Things!
