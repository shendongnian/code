    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace tcpconnect
    {
        class Program
        {
            static void Main(string[] args)
            {
                Connect1("127.0.0.1", 9090);
    
                Console.Read();
            }
    
            // Synchronous connect using IPAddress to resolve the  
            // host name. 
            public static void Connect1(string host, int port)
            {
                IPAddress[] IPs = Dns.GetHostAddresses(host);
    
                Socket s = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
    
                Console.WriteLine("Establishing Connection to {0}",
                    host);
                s.Connect(IPs[0], port);
    
                byte[] howdyBytes = Encoding.ASCII.GetBytes("Howdy");
                s.Send(howdyBytes);
                byte[] buffer = new byte[50];
                s.Receive(buffer);
                Console.Write(Encoding.ASCII.GetString(buffer));
                Console.WriteLine("Connection established");
            }
        }
    }
