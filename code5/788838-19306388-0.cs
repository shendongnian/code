    private byte[] prepareData(string longFileName, string shortFileName)
    {
        try
        {
            byte[] fileNameByte = Encoding.ASCII.GetBytes(shortFileName);
            byte[] fileData = File.ReadAllBytes(longFileName);
            byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
            byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
            fileNameLen.CopyTo(clientData, 0);
            fileNameByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileNameByte.Length);
            return clientData;
        }
        catch
        {
        }
    }
    private void sendData(string clientIP, int clientPort, byte[] clientData)
    {
        TcpClient clientSocket = new TcpClient(clientIP, clientPort);
        NetworkStream networkStream = clientSocket.GetStream();
        networkStream.Write(clientData, 0, clientData.GetLength(0));
        networkStream.Close();
        clientSocket.Close();
    }
