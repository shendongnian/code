    var client = new TcpClient("localhost", 25);
    const string crlf = "\r\n";
    var networkStream = client.GetStream();
    var streamReader = new StreamReader(client.GetStream());
            
    // Receive data from server
    var serverResponse = streamReader.ReadLine();
    Console.WriteLine("Server: " + serverResponse);
    // Send data to server
    const string data = "Command to server " + crlf;
    byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
    networkStream.Write(buffer, 0, buffer.Length);
            
    networkStream.Close();
    client.Close();
