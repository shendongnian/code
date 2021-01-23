    class Broadcst  
    {  
      public static void Main()  
      {  
       Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,  
                    ProtocolType.Udp);  
       IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);  
       IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 9050);  
       string hostname = Dns.GetHostName();  
       byte[] data = Encoding.ASCII.GetBytes(hostname);  
       sock.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.Broadcast, 1);  
       sock.SendTo(data, iep1);  
       sock.SendTo(data, iep2);  
       sock.Close();  
      }  
    }  
    
    class RecvBroadcst  
    {  
      public static void Main()  
      {  
       Socket sock = new Socket(AddressFamily.InterNetwork,  
               SocketType.Dgram, ProtocolType.Udp);  
       IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);  
       sock.Bind(iep);  
       EndPoint ep = (EndPoint)iep;  
       Console.WriteLine("Ready to receive…");  
       byte[] data = new byte[1024];  
       int recv = sock.ReceiveFrom(data, ref ep);  
       string stringData = Encoding.ASCII.GetString(data, 0, recv);  
       Console.WriteLine("received: {0} from: {1}",stringData, ep.ToString());  
       data = new byte[1024];  
       recv = sock.ReceiveFrom(data, ref ep);  
       stringData = Encoding.ASCII.GetString(data, 0, recv);  
       Console.WriteLine("received: {0} from: {1}",stringData, ep.ToString());  
       sock.Close();  
      }  
    }  
