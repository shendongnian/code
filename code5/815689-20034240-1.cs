    //using System.Net
    //using System.Net.Sockets
    TcpListener tcpListener = new TcpListener(IPAddress.Any, 27015);
    tcpListener.Start();
    
    //code to wait for a client to connect, omitted for simplicity
    
    TcpClient connectedClient = tcpListener.AcceptTcpClient(); 
    
    //#1: retrieve the local endpoint of the client (on the server)
    IPEndPoint clientEndPoint = (IPEndPoint)connectedClient.Client.LocalEndPoint;
    
    //#2: get the ip-address of the endpoint (and cast it to string)
    string connectedToAddress = clientEndPoint.Address.ToString();
    
    //#3: retrieve the host entry from the dns for the ip address
    IPHostEntry hostEntry = Dns.GetHostEntry(connectedToAddress);
       
    //print the fqdn
    Console.WriteLine("FQDN: " + hostEntry.HostName);
