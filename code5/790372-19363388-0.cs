    using System;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    
    public class App
    {
            public static int Main (string[] args)
            {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Unspecified);
                    foreach(NetworkInterface nic in nics)
                    {
                            byte[] name = System.Text.Encoding.ASCII.GetBytes(nic.Description);
                            byte[] request = new byte[32];
                            Array.Copy(name, request, name.Length);
                            bool wireless;
                            try
                            {
                                    // SIOCGIWNAME is 0x8b01
                                    socket.IOControl(0x8b01, request, request);
                                    wireless = true;
                            } catch (SocketException) {
                                    wireless = false;
                            }
                            Console.WriteLine("{0} wireless={1}", nic.Description, wireless);
                    }
                    return 0;
            }
    }
