    FileTransfer fileTransfer = new FileTransfer();
    fileTransfer.Name = "TestFile";
    fileTransfer.Content = System.Convert.ToBase64String(File.ReadAllBytes("c:\\data\\test.html"));
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(fileTransfer.GetType());
    TcpClient client = new TcpClient();
    client.Connect(IPAddress.Parse("127.0.0.1"), 40399);
    Stream stream = client.GetStream();
    x.Serialize(stream, fileTransfer);
    client.Close();
