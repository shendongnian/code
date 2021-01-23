    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    
    namespace UDPSENDER
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sender = new UdpClient("127.0.0.1", 8749);
    
                while (true)
                {
                    Console.WriteLine("Message: ");
                    var data = Encoding.Default.GetBytes(Console.ReadLine());
                    sender.Send(data, data.Length);
                }
            }
        }
    }
