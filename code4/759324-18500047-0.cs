    var writer = new StringWriter();
    writer.WriteLine("Stuff!");
    writer.WriteLine("Things!");
    ...
    var bytes = new ASCIIEncoding().GetBytes(writer.GetStringBuilder().ToString());
    _udpClient.Send(bytes, bytes.Length, _host, _port);
