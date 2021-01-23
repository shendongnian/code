    string ip = "asimov.freenode.net";
    string nick = "NICK IKESBOT \r\n";
    // format is: USER <username> * * :<realname>
    string user = "USER IKESBOT * * :IKESBOT\r\n";
    string join = "JOIN #NetChat\r\n";
    int port = 6667;
    const int recvBufSize = 8162;
    byte[] recvbBuf = new byte[recvBufSize];
    //stores the nick
    byte[] nickBuf = Encoding.ASCII.GetBytes(nick);
    byte[] userBuf = Encoding.ASCII.GetBytes(user);
    //Stores the room join
    byte[] joinBuf = Encoding.ASCII.GetBytes(join);
    Socket conn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    conn.Connect(ip, port);
    conn.Send(nickBuf, nickBuf.Length, SocketFlags.None);
    conn.Send(userBuf, userBuf.Length, SocketFlags.None);
    conn.Send(joinBuf, joinBuf.Length, SocketFlags.None);
