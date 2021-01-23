    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    
    namespace UDPLISTENER
    {
        class Program
        {
            static void Main(string[] args)
            {
                var port = 8750;
                var listener = new UdpClient(port);
                var group = new IPEndPoint(IPAddress.Any, port);
    
                Console.WriteLine("Listening for datagrams on port {0}", port);
                while(true)
                {
                    var data = listener.Receive(ref group);
                    Console.WriteLine("{0}: {1}", group.ToString(), Encoding.Default.GetString(data, 0, data.Length));
                }
            }
        }
    }
