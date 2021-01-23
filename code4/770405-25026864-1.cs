    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace sixsharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                if(args.Length <= 0) //run as server
                    RunServer();
                else
                    RunClient(args);
                Console.WriteLine("Press enter to close.");
                Console.ReadLine();
            }
            static void RunServer()
            {
                using(Socket serv = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp))
                {
                    serv.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, 0);
                    serv.Bind(new IPEndPoint(IPAddress.IPv6Any, 1337));
                    serv.Listen(5);
                    Console.Write("Listening for client connection...");
                    using(Socket client = serv.Accept())
                    {
                        Console.WriteLine("Client connection accepted from {0}", client.RemoteEndPoint.ToString());
                        byte[] buf = new byte[128];
                        client.Receive(buf, 128, SocketFlags.None);
                        Console.WriteLine("Got \'{0}\' from client", Encoding.ASCII.GetString(buf));
                        Console.WriteLine("Echoing response");
                        client.Send(buf);
                        client.Shutdown(SocketShutdown.Both);
                    }
                }
                Console.WriteLine("Done.");
            }
            static void RunClient(string[] args)
            {
                using(Socket client = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp))
                {
                    client.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, 0);
                    Console.WriteLine("Setting up address, input is {0}", args[0]);
                    IPEndPoint ep;
                    try
                    {
                        ep = new IPEndPoint(IPAddress.Parse(args[0]), 1337);
                    }
                    catch(FormatException fe)
                    {
                        Console.WriteLine("IP address was improperly formatted and not parsed.");
                        Console.WriteLine("Detail: {0}", fe.Message);
                        return;
                    }
                    if(ep.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ep = new IPEndPoint(ep.Address.MapToIPv6(), ep.Port);
                        if(!ep.Address.IsIPv4MappedToIPv6 || ep.Address.AddressFamily != AddressFamily.InterNetworkV6)
                        {
                            Console.WriteLine("Error mapping IPv4 address to IPv6");
                            return;
                        }
                    }
                    Console.WriteLine("Connecting to server {0} ...", ep.ToString());
                    try
                    {
                        client.Connect(ep);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Unable to connect.\n Detail: {0}", ex.Message);
                        return;
                    }
                    client.Send(Encoding.ASCII.GetBytes("This is a test message. Hello!"));
                    byte[] buf = new byte[128];
                    client.Receive(buf);
                    Console.WriteLine("Got back from server: {0}", Encoding.ASCII.GetString(buf));
                    client.Shutdown(SocketShutdown.Both);
                }
                Console.WriteLine("Done.");
            }
        }
    }
