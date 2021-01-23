    sing System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    
    namespace UDPCLIENT
    {
        class Program
        {
            static void Main(string[] args)
            {
                int listeningPort = 8749, dispatchPort = 8750;
                var listener = new UdpClient(listeningPort);
                var group = new IPEndPoint(IPAddress.Any, listeningPort);
    
                // Republish client
                var client = new UdpClient("127.0.0.1", dispatchPort);
    
                Console.WriteLine("Listening for datagrams on port {0}", listeningPort);
                while (true)
                {
                    var data = listener.Receive(ref group);
                    Console.WriteLine("{0}: {1}", group.ToString(), Encoding.Default.GetString(data, 0, data.Length));
                    client.Send(data, data.Length);
                }
            }
        }
    }
