    public class StartUp
    {
        public StartUp()
        {
            WorldData = new world.WorldData();
            ListenerTcp = new Server.tcpserver.TcpServer( this );  // <--- !!!
        }
        public Server.tcpserver.TcpServer ListenerTcp;
        public world.WorldData WorldData;
        // ...
    }
