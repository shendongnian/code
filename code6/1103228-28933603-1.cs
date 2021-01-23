    using System;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;
    
    class Server
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpServerChannel(1234), false);
            RemotingConfiguration.ApplicationName = "Test";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(MyServer));
            Console.WriteLine("Server listening ...");
            Console.ReadLine();
        }
    }
