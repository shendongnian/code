        using System;
        using System.Text;
        using System.Net;
        using System.Net.Sockets;
        using System.IO;
        
        
        namespace socket_prog
        {
            class Client
            {
                private static void Main(String[] args)
                {
                    byte[] data = new byte[10];
        
                    IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAdress = iphostInfo.AddressList[0];
                    IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, 32000);
        
                    Socket client = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        
                    try
                    {
                        client.Connect(ipEndpoint);
        
                        Console.WriteLine("Socket created to {0}", client.RemoteEndPoint.ToString());
        
                        byte[] sendmsg = Encoding.ASCII.GetBytes("This is from Client\n");
        
                        int n = client.Send(sendmsg);
        
                        int m = client.Receive(data);
        
                        Console.WriteLine("" + Encoding.ASCII.GetString(data));
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
        
                    Console.WriteLine("Transmission end.");
                    Console.ReadKey();
        
                }
            }
        }
    
