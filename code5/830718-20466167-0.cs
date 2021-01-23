    using System;
    using System.Net.NetworkInformation;
    
    namespace NetStatNet
    {
        class Program
        {
            static void Main(string[] args)
            {
                var props = IPGlobalProperties.GetIPGlobalProperties();
    
                Console.WriteLine("  Proto  Local Address          Foreign Address        State");
    
                foreach (var conn in props.GetActiveTcpConnections())
                    Console.WriteLine("  TCP    {0,-23}{1,-23}{2}",
                                      conn.LocalEndPoint, conn.RemoteEndPoint, conn.State);
    
                foreach (var listener in props.GetActiveTcpListeners())
                    Console.WriteLine("  TCP    {0,-23}{1,-23}{2}", listener, "", "Listening");
    
                foreach (var listener in props.GetActiveUdpListeners())
                    Console.WriteLine("  UDP    {0,-23}{1,-23}{2}", listener, "", "Listening");
    
                Console.Read();
            }
        }
    }
