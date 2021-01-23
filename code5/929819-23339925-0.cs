    // Create new socket for STUN client.
    Socket socket = new Socket
        (AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
    socket.Bind(new IPEndPoint(IPAddress.Any,0));
    
    // Query STUN server
    STUN_Result result = STUN_Client.Query("stunserver.org",3478,socket);
    if(result.NetType != STUN_NetType.UdpBlocked){
        // UDP blocked or !!!! bad STUN server
    }
    else{
        IPEndPoint publicEP = result.PublicEndPoint;
        // Do your stuff
    }
