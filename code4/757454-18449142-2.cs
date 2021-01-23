    static void Main(string[] args)
    {
        Socket m_sock= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_sock.Connect(ipendLocalhost);
        SendRequest(m_sock, "command");
    }
    static void SendRequest(Socket m_sock, string sCommand)
    {
       m_sock.Send(szCommand, iBytesToSend, SocketFlags.None);
    }
