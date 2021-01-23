    public void SendTelnetCommand(string Command, string IPofAP)
    {
        TcpClient tcpSocket = new TcpClient(IPofAP, 23);
    
        if (!tcpSocket.Connected) return;
        byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(Command);
        tcpSocket.GetStream().Write(buf, 0, buf.Length);
    
        if (tcpSocket.Connected) tcpSocket.Close();
    }
