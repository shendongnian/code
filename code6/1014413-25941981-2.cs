    public class TcpServer
    {
        int counter = 0;
        private StartUp startUp:
        
        public TcpServer(StartUp startUp)
        {
            this.startUp = startUp;
        }
        public void StartListening()
        {
            // ...
            var worldData = this.startUp.WorldData;     // <--- !!!
            // ...
        }
      
        // ...
    }
