    // var client = new TcpClient();
    var ns = client.GetStream();
    int IDMessage = 4; // Length ID Message
    SendBytes(ns, BitConverter.GetBytes(IDMessage));
    int IDObserver = 2;
    SendBytes(ns, BitConverter.GetBytes(IDObserver));
    Lenght = double.Parse(LenghtTXT.Text)
    Lenght = Lenght * Math.Pow(10, 5);
    SendBytes(ns, BitConverter.GetBytes(Lenght));
