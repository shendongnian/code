    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                try
                {
                    IPAddress IP = IPAddress.Parse("127.0.0.1");
    
                    TcpListener Listener = new TcpListener(IP, 8001);
                    Listener.Start();
    
                    Socket s = Listener.AcceptSocket();
                    Console.WriteLine("Conected");
                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("ping"));
                    Console.WriteLine("Data sent");
    
                    s.Close();
                    Listener.Stop();
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
    
                Console.ReadKey();
            }
        }
    }
