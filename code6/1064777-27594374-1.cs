    // var client = new TcpClient();
    var ms = new MemoryStream();
    int IDMessage = 4; // Length ID Message
    SendBytes(ms, BitConverter.GetBytes(IDMessage));
    int IDObserver = 2;
    SendBytes(ms, BitConverter.GetBytes(IDObserver));
    Lenght = double.Parse(LenghtTXT.Text)
    Lenght = Lenght * Math.Pow(10, 5);
    SendBytes(ms, BitConverter.GetBytes(Lenght));
    byte[] allBytes = ms.ToBytes();
    client.GetStream().SendBytes(allBytes, 0, allBytes.Length);
